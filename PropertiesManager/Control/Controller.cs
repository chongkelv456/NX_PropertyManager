using PropertiesManager.Model;
using PropertiesManager.Services;
using PropertiesManager.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesManager.Control
{
    public class Controller
    {
        private UserForm uf;
        private NxDrawing drawing;
        private DateTime sessionStartTime;
       
        private bool debugMode = false;                                                               

        public Controller()
        {                        
            if(debugMode)
                System.Diagnostics.Debugger.Launch();

            sessionStartTime = DateTime.Now;
            uf = new UserForm(this);
            drawing = new NxDrawing(this);                       

            uf.Show();
        }

        public void Apply()
        {
            try
            {
                var title_infos = drawing.GetAttributesInfos(
                        NxDrawing.CATEGORY_TITLE,
                        drawing.GetTitle_KeyValue());

                drawing.SetAttributes(title_infos);

                var tool_infos = drawing.GetAttributesInfos(NxDrawing.CATEGORY_TOOL, drawing.GetTool_KeyValue());
                drawing.SetAttributes(tool_infos);

                drawing.DeleteStdPartAttribute();

                // Log successful usage with meaningful data
                LogSuccessfulUsage();
            }
            catch (Exception ex)
            {
                // Log error usage
                UsageTracker.LogError("PropertiesManager", ex);
                throw; // Re-throw to maintain original behavior                
            }
        }

        private void LogSuccessfulUsage()
        {
            try
            {
                var duration = DateTime.Now - sessionStartTime;

                var record = new ApiUsageRecord
                {
                    ApiName = "PropertiesManager",
                    EngineerName = uf.TextDesginer,
                    Version = GetApiVersion(),
                    UsedTime = DateTime.Now,
                    ComputerName = Environment.MachineName,
                    SessionId = GetSessionId(),
                    Duration = duration,
                    Status = "Success",
                    Message = $"PartType:{uf.TextPartType}|ItemName:{uf.TextItemName}|DrawingCode:{uf.TextDwgCode}"
                };

                UsageTracker.Service.LogUsage(record);
            }
            catch
            {
                // Silent fail - don't disrupt main functionality
            }
        }

        private string GetApiVersion()
        {
            try
            {
                var assembly = System.Reflection.Assembly.GetExecutingAssembly();
                return assembly.GetName().Version?.ToString() ?? "1.1.0.0";
            }
            catch
            {
                return "1.1.0.0";
            }
        }

        private string GetSessionId()
        {
            // Use the same session ID as the tracking service for consistency
            return UsageTracker.Service.GetType()
                .GetField("SessionId", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)
                ?.GetValue(null)?.ToString() ?? Guid.NewGuid().ToString();
        }

        public UserForm GetUserForm()
        {
            return uf;
        }

        public NxDrawing GetDrawing()
        {
            return drawing;
        }

        public void StdApply()
        {
            var tool_infos = drawing.GetAttributesInfos(
                NxDrawing.CATEGORY_TOOL, 
                drawing.GetStandardPart_KeyValue());
            drawing.SetAttributes(tool_infos);
        }
    }
}
