using PropertiesManager.Control;
using PropertiesManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesManager.Services
{
    /// <summary>
    /// Factory for creating service instances with proper dependency injection
    /// </summary>
    public class ServiceFactory : IServiceFactory
    {
        // Singleton instances for stateless services (optional performance optimization)
        private static readonly Lazy<IDrawingCodeService> _drawingCodeService =
            new Lazy<IDrawingCodeService>(() => new DrawingCodeService());

        private static readonly Lazy<IFileSystemService> _fileSystemService =
            new Lazy<IFileSystemService>(() => new FileSystemService());

        public CodeGeneratorService CreateCodeGeneratorService(Controller control, ProjectInfoModel projectInfo)
        {
            if (control == null)
                throw new ArgumentNullException(nameof(control));

            if (projectInfo == null)
                throw new ArgumentNullException(nameof(projectInfo));

            var fileSystemService = CreateFileSystemService();
            var drawingCodeService = CreateDrawingCodeService();
            var versionAnalysisService = CreateVersionAnalysisService(fileSystemService);
            var runningNumberService = CreateRunningNumberService(fileSystemService, drawingCodeService);

            return new CodeGeneratorService(
                control,
                projectInfo,
                fileSystemService,
                versionAnalysisService,
                runningNumberService,
                drawingCodeService);
        }

        public IFileSystemService CreateFileSystemService()
        {
            return _fileSystemService.Value;
        }

        public IDrawingCodeService CreateDrawingCodeService()
        {
            return _drawingCodeService.Value;
        }

        public IVersionAnalysisService CreateVersionAnalysisService(IFileSystemService fileSystemService = null)
        {
            return new VersionAnalysisService(fileSystemService ?? CreateFileSystemService());
        }

        public IRunningNumberService CreateRunningNumberService(IFileSystemService fileSystemService = null, IDrawingCodeService drawingCodeService = null)
        {
            return new RunningNumberService(
                fileSystemService ?? CreateFileSystemService(), 
                drawingCodeService ?? CreateDrawingCodeService());
        }        
    }
}
