using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertiesManager.Control;
using PropertiesManager.Model;

namespace PropertiesManager.Services
{
    /// <summary>
    /// Factory for creating service instances with proper dependency injection
    /// </summary>
    public interface IServiceFactory
    {
        /// <summary>
        /// Creates a new CodeGeneratorService instance
        /// </summary>
        /// <param name="control">Controller instance</param>
        /// <param name="projectInfo">Project information model</param>
        /// <returns>Configured CodeGeneratorService</returns>
        CodeGeneratorService CreateCodeGeneratorService(Controller control, ProjectInfoModel projectInfo);

        /// <summary>
        /// Creates a new FileSystemService instance
        /// </summary>
        /// <returns>FileSystemService instance</returns>
        IFileSystemService CreateFileSystemService();

        /// <summary>
        /// Creates a new DrawingCodeService instance
        /// </summary>
        /// <returns>DrawingCodeService instance</returns>
        IDrawingCodeService CreateDrawingCodeService();

        /// <summary>
        /// Creates a new VersionAnalysisService instance
        /// </summary>
        /// <param name="fileSystemService">File system service dependency</param>
        /// <returns>VersionAnalysisService instance</returns>
        IVersionAnalysisService CreateVersionAnalysisService(IFileSystemService fileSystemService = null);

        /// <summary>
        /// Creates a new RunningNumberService instance
        /// </summary>
        /// <param name="fileSystemService">File system service dependency</param>
        /// <param name="drawingCodeService">Drawing code service dependency</param>
        /// <returns>RunningNumberService instance</returns>
        IRunningNumberService CreateRunningNumberService(IFileSystemService fileSystemService = null, IDrawingCodeService drawingCodeService = null);
    }
}
