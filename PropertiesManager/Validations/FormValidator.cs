using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesManager.Validations
{
    /// <summary>
    /// Extracts validations logic from forms to improve separation of concerns
    /// </summary>
    public class FormValidator
    {
        private readonly List<string> _requiredFields = new List<string>
        {
            nameof(FormValidationData.Path),
            nameof(FormValidationData.PartType),
            nameof(FormValidationData.StationNumber),
            nameof(FormValidationData.ItemName),
            nameof(FormValidationData.DrawingCode),
            nameof(FormValidationData.Material),
            nameof(FormValidationData.Hardness),
            nameof(FormValidationData.Thickness),
            nameof(FormValidationData.Width),
            nameof(FormValidationData.Length),
            nameof(FormValidationData.Model),
            nameof(FormValidationData.Part),
            nameof(FormValidationData.CodePrefix),
            nameof(FormValidationData.Designer)
        };

        /// <summary>
        /// Validate all form inputs for enabling Apply button
        /// </summary>
        public ValidationResult ValidateForApply(FormValidationData data)
        {
            var result = new ValidationResult { IsValid = true };

            // Validate input information
            var projectInfoValidation = ValidateInputField(data);
            if(!projectInfoValidation.IsValid)
            {
                result.Errors.AddRange(projectInfoValidation.Errors);
                result.IsValid = false;
            }            

            // Validate Path
            var pathValidation = ValidatePath(data.Path);
            if (!pathValidation.IsValid)
            {
                result.Errors.AddRange(pathValidation.Errors);
                result.IsValid = false;
            }

            return result;
        }

        private ValidationResult ValidatePath(string path)
        {
            var result = new ValidationResult { IsValid = true };

            if(string.IsNullOrEmpty(path))
            {
                result.AddError("Project directory is required");
                return result;
            }

            if(!Directory.Exists(path))
            {
                result.AddError($"Project directory does not exist: {path}");
                return result;
            }

            return result;
        }

        private ValidationResult ValidateInputField(FormValidationData data)
        {
            var result = new ValidationResult { IsValid = true };

            foreach(var fieldName in _requiredFields)
            {
                var value = GetFieldValue(data, fieldName);
                if (string.IsNullOrEmpty(value))
                {
                    result.AddError($"{GetDisplayName(fieldName)} is required");
                    continue;
                }
            }

            return result;
        }

        private string GetFieldValue(FormValidationData data, string fieldName)
        {
            var propoerty = typeof(FormValidationData).GetProperty(fieldName);
            return propoerty?.GetValue(data) as string ?? string.Empty;

        }

        private object GetDisplayName(string fieldName)
        {
            var displayNames = new Dictionary<string, string>
            {
                { nameof(FormValidationData.Path), "Path" },
                { nameof(FormValidationData.PartType), "Part Type" },
                { nameof(FormValidationData.StationNumber), "Station Number" },
                { nameof(FormValidationData.ItemName), "Item Name" },
                { nameof(FormValidationData.DrawingCode), "Drawing Code" },
                { nameof(FormValidationData.Material), "Material" },
                { nameof(FormValidationData.Hardness), "Hardness" },
                { nameof(FormValidationData.Thickness), "Thickness" },
                { nameof(FormValidationData.Width), "Width" },
                { nameof(FormValidationData.Length), "Length" },
                { nameof(FormValidationData.Model), "Model" },
                { nameof(FormValidationData.Part), "Part" },
                { nameof(FormValidationData.CodePrefix), "Code Prefix" },
                { nameof(FormValidationData.Designer), "Designer" }
            };

            return displayNames.TryGetValue(fieldName, out var displayName) ? displayName : fieldName;
        }
    }
}
