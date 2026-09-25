using AssetStoreTools.Validator.Data;
using AssetStoreTools.Validator.Services.Validation;
using AssetStoreTools.Validator.TestDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;

namespace AssetStore.Validator.TestMethods
{
    internal class CheckStaticVariables : ITestScript
    {
        private GenericTestConfig _config;
        private IAssetUtilityService _assetUtilityService;
        private IScriptUtilityService _scriptUtilityService;

        private class PotentialIssues
        {
            public List<MonoScript> FastEnterPlayModeStaticVarScripts;
            public List<MonoScript> FastEnterPlayModeStaticEventScripts;

            public PotentialIssues()
            {
                FastEnterPlayModeStaticVarScripts = new List<MonoScript>();
                FastEnterPlayModeStaticEventScripts = new List<MonoScript>();
            }

            public bool HasIssues => FastEnterPlayModeStaticVarScripts.Count > 0 || FastEnterPlayModeStaticEventScripts.Count > 0;
        }

        // Constructor also accepts dependency injection of registered IValidatorService types
        public CheckStaticVariables(GenericTestConfig config, IAssetUtilityService assetUtilityService, IScriptUtilityService scriptUtilityService)
        {
            _config = config;
            _assetUtilityService = assetUtilityService;
            _scriptUtilityService = scriptUtilityService;
        }

        public TestResult Run()
        {
            var result = new TestResult() { Status = TestResultStatus.Undefined };

            var issues = CheckIssues();
            if (issues.HasIssues)
            {
                if (issues.FastEnterPlayModeStaticVarScripts.Count > 0)
                {
                    result.Status = TestResultStatus.Warning;
                    result.AddMessage("The following scripts contain static fields and/or properties. You should take caution that their values are correctly reset during Play mode state change, if needed");
                    foreach (var obj in issues.FastEnterPlayModeStaticVarScripts)
                        result.AddMessage(null, null, obj);
                }

                if (issues.FastEnterPlayModeStaticEventScripts.Count > 0)
                {
                    result.Status = TestResultStatus.Warning;
                    result.AddMessage("The following scripts contain static events. You should take caution that their subscribers are correctly unregistered during Play mode state change, if needed");
                    foreach (var obj in issues.FastEnterPlayModeStaticEventScripts)
                        result.AddMessage(null, null, obj);
                }
            }
            else
            {
                result.Status = TestResultStatus.Pass;
                result.AddMessage("No static variables or events were found!");
            }

            return result;
        }

        private PotentialIssues CheckIssues()
        {
            var scriptObjects = _assetUtilityService.GetObjectsFromAssets(_config.ValidationPaths, AssetType.MonoScript);
            var scripts = scriptObjects.Select(x => x as MonoScript).ToList();
            var scriptTypes = _scriptUtilityService.GetTypesFromScriptAssets(scripts);

            var result = new PotentialIssues();

            CheckFastEnterPlayMode(scriptTypes, result);

            return result;
        }

        private void CheckFastEnterPlayMode(IReadOnlyDictionary<MonoScript, IList<Type>> scripts, PotentialIssues result)
        {
            foreach (var kvp in scripts)
            {
                var scriptAsset = kvp.Key;
                var scriptTypes = kvp.Value;

                var hasStaticVars = false;
                var hasStaticEvents = false;

                foreach (var t in scriptTypes)
                {
                    if (TypeContainsStaticVars(t))
                        hasStaticVars = true;

                    if (TypeContainsStaticEvents(t))
                        hasStaticEvents = true;

                    if (hasStaticVars && hasStaticEvents)
                        break;
                }

                if (hasStaticVars)
                    result.FastEnterPlayModeStaticVarScripts.Add(scriptAsset);

                if (hasStaticEvents)
                    result.FastEnterPlayModeStaticEventScripts.Add(scriptAsset);
            }
        }

        private bool TypeContainsStaticVars(Type t)
        {
            var staticFields = t.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).Where(x => !x.IsLiteral && !x.IsInitOnly).ToArray();
            var staticProperties = t.GetProperties(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).Where(x => x.CanWrite).ToArray();

            return staticFields.Length > 0 || staticProperties.Length > 0;
        }

        private bool TypeContainsStaticEvents(Type t)
        {
            var staticEvents = t.GetEvents(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            return staticEvents.Length > 0;
        }
    }
}
