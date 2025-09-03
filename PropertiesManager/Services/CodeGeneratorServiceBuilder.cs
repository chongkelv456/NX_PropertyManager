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
    /// Builder pattern for creating CodeGeneratorService with fluent API
    /// </summary>
    public class CodeGeneratorServiceBuilder
    {
        private Controller _control;
        private ProjectInfoModel _projectInfo;
        private IFileSystemService _fileSystemService;
        private IVersionAnalysisService _versionAnalysisService;
        private IRunningNumberService _runningNumberService;
        private IDrawingCodeService _drawingCodeService;

        public CodeGeneratorServiceBuilder WithController(Controller control)
        {
            _control = control ?? throw new ArgumentNullException(nameof(control));
            return this;
        }

        public CodeGeneratorServiceBuilder WithProjectInfo(ProjectInfoModel projectInfo)
        {
            _projectInfo = projectInfo ?? throw new ArgumentNullException(nameof(projectInfo));
            return this;
        }

        public CodeGeneratorServiceBuilder WithFileSystemService(IFileSystemService fileSystemService)
        {
            _fileSystemService = fileSystemService;
            return this;
        }

        public CodeGeneratorServiceBuilder WithVersionAnalysisService(IVersionAnalysisService versionAnalysisService)
        {
            _versionAnalysisService = versionAnalysisService;
            return this;
        }

        public CodeGeneratorServiceBuilder WithRunningNumberService(IRunningNumberService runningNumberService)
        {
            _runningNumberService = runningNumberService;
            return this;
        }

        public CodeGeneratorServiceBuilder WithDrawingCodeService(IDrawingCodeService drawingCodeService)
        {
            _drawingCodeService = drawingCodeService;
            return this;
        }

        public CodeGeneratorServiceBuilder WithDefaults()
        {
            var factory = new ServiceFactory();

            _fileSystemService ??= factory.CreateFileSystemService();
            _drawingCodeService ??= factory.CreateDrawingCodeService();
            _versionAnalysisService ??= factory.CreateVersionAnalysisService(_fileSystemService);
            _runningNumberService ??= factory.CreateRunningNumberService(_fileSystemService, _drawingCodeService);

            return this;
        }

        public CodeGeneratorService Build()
        {
            if (_control == null)
                throw new InvalidOperationException("Controller is required. Call WithController() before Build().");

            if (_projectInfo == null)
                throw new InvalidOperationException("ProjectInfo is required. Call WithProjectInfo() before Build().");

            // Apply defaults if services not explicitly set
            WithDefaults();

            return new CodeGeneratorService(
                _control,
                _projectInfo,
                _fileSystemService,
                _versionAnalysisService,
                _runningNumberService,
                _drawingCodeService);
        }

        // Static factory methods for common scenarios
        public static CodeGeneratorService CreateDefault(Controller control, ProjectInfoModel projectInfo)
        {
            return new CodeGeneratorServiceBuilder()
                .WithController(control)
                .WithProjectInfo(projectInfo)
                .WithDefaults()
                .Build();
        }

        public static CodeGeneratorService CreateForTesting(
            Controller control,
            ProjectInfoModel projectInfo,
            IFileSystemService mockFileSystem = null,
            IVersionAnalysisService mockVersionAnalysis = null,
            IRunningNumberService mockRunningNumber = null,
            IDrawingCodeService mockDrawingCode = null)
        {
            var builder = new CodeGeneratorServiceBuilder()
                .WithController(control)
                .WithProjectInfo(projectInfo);

            if (mockFileSystem != null)
                builder.WithFileSystemService(mockFileSystem);

            if (mockVersionAnalysis != null)
                builder.WithVersionAnalysisService(mockVersionAnalysis);

            if (mockRunningNumber != null)
                builder.WithRunningNumberService(mockRunningNumber);

            if (mockDrawingCode != null)
                builder.WithDrawingCodeService(mockDrawingCode);

            return builder.WithDefaults().Build();
        }
    }
}
