using AssetStoreTools.Validator.Data;
using AssetStoreTools.Validator.Services.Validation;
using AssetStoreTools.Validator.TestDefinitions;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

namespace AssetStore.Validator.TestMethods
{
    internal class CheckSRPCompatibleMaterials : ITestScript
    {
        private const string UniversalPipelineTag = "UniversalPipeline";
        private const string HDRenderPipelineTag = "HDRenderPipeline";
        private static readonly ShaderTagId RenderPipelineTagId = new ShaderTagId("RenderPipeline");

        private GenericTestConfig _config;
        private IAssetUtilityService _assetUtility;

        public CheckSRPCompatibleMaterials(GenericTestConfig config, IAssetUtilityService assetUtility)
        {
            _config = config;
            _assetUtility = assetUtility;
        }

        public TestResult Run()
        {
            var result = new TestResult() { Status = TestResultStatus.Undefined };

            var materials = CollectAllMaterials();
            var shaderFiles = CollectAllShaderFiles();

            if (materials.Count == 0 && shaderFiles.Count == 0)
            {
                result.Status = TestResultStatus.Pass;
                result.AddMessage("No materials or shader files found in package — SRP compatibility check skipped.");
                return result;
            }

            var incompatibleMaterials = GetIncompatibleMaterials(materials);
            var incompatibleShaders = GetIncompatibleShaderFiles(shaderFiles);

            if (incompatibleMaterials.Count == 0 && incompatibleShaders.Count == 0)
            {
                result.Status = TestResultStatus.Pass;
                result.AddMessage("All shaders used by package materials and all shader files in the package are SRP-compatible.");
                return result;
            }

// #if UNITY_6000_6_OR_NEWER
//             result.Status = TestResultStatus.VariableSeverityIssue;
// #else
//             result.Status = TestResultStatus.Warning;
// #endif
            result.Status = TestResultStatus.Warning;

            if (incompatibleMaterials.Count > 0)
                result.AddMessage("Materials with non-SRP-compatible shaders:", null, incompatibleMaterials.ToArray());

            if (incompatibleShaders.Count > 0)
                result.AddMessage("Non-SRP-compatible shaders:", null, incompatibleShaders.ToArray());

            return result;
        }

        private List<Material> CollectAllMaterials()
        {
            var uniqueMaterials = new HashSet<Material>();

            foreach (var material in _assetUtility.GetObjectsFromAssets<Material>(_config.ValidationPaths, AssetType.Material))
            {
                if (material != null)
                    uniqueMaterials.Add(material);
            }

            var models = _assetUtility.GetObjectsFromAssets<GameObject>(_config.ValidationPaths, AssetType.Model);
            foreach (var model in models)
            {
                var modelPath = _assetUtility.ObjectToAssetPath(model);
                foreach (var subAssetMaterial in AssetDatabase.LoadAllAssetsAtPath(modelPath).OfType<Material>())
                {
                    if (subAssetMaterial != null)
                        uniqueMaterials.Add(subAssetMaterial);
                }
            }

            return uniqueMaterials.ToList();
        }

        private List<Shader> CollectAllShaderFiles()
        {
            var uniqueShaders = new HashSet<Shader>();
            foreach (var shader in _assetUtility.GetObjectsFromAssets<Shader>(_config.ValidationPaths, AssetType.Shader))
            {
                if (shader != null)
                    uniqueShaders.Add(shader);
            }
            return uniqueShaders.ToList();
        }

        private static List<Material> GetIncompatibleMaterials(List<Material> materials)
        {
            var incompatible = new List<Material>();
            foreach (var material in materials)
            {
                if (material.shader != null && !IsSrpCompatible(material.shader))
                    incompatible.Add(material);
            }
            return incompatible;
        }

        private static List<Shader> GetIncompatibleShaderFiles(List<Shader> shaderFiles)
        {
            var incompatible = new HashSet<Shader>();
            foreach (var shader in shaderFiles)
            {
                if (!IsSrpCompatible(shader))
                    incompatible.Add(shader);
            }
            return incompatible.ToList();
        }

        private static bool IsSrpCompatible(Shader shader)
        {
            for (int i = 0; i < shader.subshaderCount; i++)
            {
                var tag = shader.FindSubshaderTagValue(i, RenderPipelineTagId).name;
                if (tag == UniversalPipelineTag || tag == HDRenderPipelineTag)
                    return true;
            }
            return false;
        }
    }
}