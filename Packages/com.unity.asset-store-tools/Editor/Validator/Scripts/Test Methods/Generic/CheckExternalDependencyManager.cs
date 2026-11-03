using AssetStoreTools.Validator.Data;
using AssetStoreTools.Validator.Services.Validation;
using AssetStoreTools.Validator.TestDefinitions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AssetStoreTools.Validator.TestMethods
{
    internal class CheckExternalDependencyManager : ITestScript
    {
        private const string EdmLink = "https://docs.unity3d.com/Packages/com.unity.external-dependency-manager@2.0/manual/get-started-with-edm.html";
        // dll list used by Unity EDM itself
        private static readonly string[] Edm4UAssemblyFileNames =
        {
            "Google.VersionHandler.dll",
            "Google.VersionHandlerImpl.dll",
            "Google.IOSResolver.dll",
            "Google.JarResolver.dll",
            "Google.PackageManagerResolver.dll",
        };

        // Strings that point at Google's EDM4U, scanned for in documentation and scripts.
        private static readonly string[] Edm4USignatures =
        {
            "com.google.external-dependency-manager",
            "https://github.com/googlesamples/unity-jar-resolver",
        };

        private GenericTestConfig _config;
        private IAssetUtilityService _assetUtility;

        public CheckExternalDependencyManager(GenericTestConfig config, IAssetUtilityService assetUtility)
        {
            _config = config;
            _assetUtility = assetUtility;
        }

        public TestResult Run()
        {
            var result = new TestResult() { Status = TestResultStatus.Undefined };

            var edmFiles = FindEdm4UFiles();
            // If the EDM4U binaries are already bundled, scanning docs/scripts for mentions of EDM4U is redundant
            var mentionFiles = edmFiles.Count > 0 ? new List<string>() : FindEdm4UMentions();

            if (edmFiles.Count == 0 && mentionFiles.Count == 0)
            {
                result.Status = TestResultStatus.Pass;
                result.AddMessage("Google's External Dependency Manager (EDM4U) was not found in your package.");
                return result;
            }

            result.Status = TestResultStatus.Fail;

            if (edmFiles.Count > 0)
            {
                result.AddMessage(
                    "Your package contains Google's External Dependency Manager (EDM4U), which has been " +
                    $"superseded by <a href='{EdmLink}'>External Dependency Manager package</a>.\n" +
                    "EDM4U should not be bundled with your submission.");
            }

            if (mentionFiles.Count > 0)
            {
                result.AddMessage(
                    "Your package references Google's External Dependency Manager (EDM4U), which has been " +
                    $"superseded by <a href='{EdmLink}'>External Dependency Manager package</a>.\n" +
                    "Instead, users should install Unity External Dependency Manager via Package Manager");
                var objects = mentionFiles.Select(_assetUtility.AssetPathToObject).Where(x => x != null).ToArray();
                result.AddMessage("Documentation or scripts that mention Google's EDM4U:", null, objects);
            }

            return result;
        }

        private List<string> FindEdm4UFiles()
        {
            var found = new List<string>();
            foreach (var path in _config.ValidationPaths)
            {
                if (!Directory.Exists(path))
                    continue;

                foreach (var dll in Directory.GetFiles(path, "*.dll", SearchOption.AllDirectories))
                {
                    var fileName = Path.GetFileName(dll);
                    if (!Edm4UAssemblyFileNames.Any(n => string.Equals(n, fileName, StringComparison.OrdinalIgnoreCase)))
                        continue;

                    var adbPath = dll.Replace("\\", "/");
                    if (!found.Contains(adbPath))
                        found.Add(adbPath);
                }
            }
            return found;
        }

        private List<string> FindEdm4UMentions()
        {
            // Some publishers mention EDM4U in documentation, others hide the reference in scripts.
            var textPaths = _assetUtility.GetAssetPathsFromAssets(_config.ValidationPaths, AssetType.Documentation)
                .Concat(_assetUtility.GetAssetPathsFromAssets(_config.ValidationPaths, AssetType.MonoScript));

            var found = new List<string>();
            foreach (var path in textPaths)
            {
                // Skip binary docs (e.g. .pdf) we can't reliably text-scan.
                if (path.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase))
                    continue;
                if (!File.Exists(path))
                    continue;

                var text = File.ReadAllText(path);
                if (!Edm4USignatures.Any(s => text.IndexOf(s, StringComparison.OrdinalIgnoreCase) >= 0))
                    continue;

                var adbPath = path.Replace("\\", "/");
                if (!found.Contains(adbPath))
                    found.Add(adbPath);
            }
            return found;
        }
    }
}
