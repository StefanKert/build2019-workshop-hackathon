using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using PhotoStoreDemo.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoStoreDemo.Services
{
    public class ImageDescriptionService
    {
        private const string SUBSCRIPTION_KEY = "4a78a92c34b0488eb4e80652cd56f839";
        private const string ENDPOINT = "https://westus.api.cognitive.microsoft.com/";
        private const double TAG_CONFIDENCE_THRESHOLD = 0.80;

        private readonly ComputerVisionClient _computerVision;
        private readonly List<VisualFeatureTypes> _features;

        public ImageDescriptionService()
        {
            _computerVision = new ComputerVisionClient(
                new ApiKeyServiceClientCredentials(SUBSCRIPTION_KEY),
                new System.Net.Http.DelegatingHandler[] { })
            {
                Endpoint = ENDPOINT
            };

            _features = new List<VisualFeatureTypes>()
            {
                VisualFeatureTypes.Categories, VisualFeatureTypes.Description,
                VisualFeatureTypes.Faces, VisualFeatureTypes.ImageType,
                VisualFeatureTypes.Tags
            };
        }

        public async Task<PhotoDescription> GetDescriptionForImageAsync(string path)
        {
            using (var imageStream = File.OpenRead(path))
            {
                var analysis = await _computerVision.AnalyzeImageInStreamAsync(
                    imageStream, _features);

                return new PhotoDescription
                {
                    Description = analysis.Description.Captions.FirstOrDefault()?.Text,
                    Tags = analysis.Tags
                        .Where(x => x.Confidence > TAG_CONFIDENCE_THRESHOLD)
                        .Select(x => x.Name).ToList()
                };
            }
        }
    }
}
