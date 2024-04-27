using Api.Models;
using Api.Repositories;
using Api.Requests;

namespace Api.Services.ImageService
{
    public class ImageService : IImageService
    {
        private readonly List<int> jsonServerArray = new([6, 7, 8, 9]);

        private readonly List<int> sqliteArray = new([1, 2, 3, 4, 5]);

        private readonly Char[] vowelCharArray = ['a', 'e', 'i', 'o', 'u'];

        private readonly IImageRepository imageRepository;

        private readonly IJSONServerRequest jSONServerRequest;
        public ImageService(IImageRepository imageRepository, IJSONServerRequest jSONServerRequest)
        {
            this.imageRepository = imageRepository;
            this.jSONServerRequest = jSONServerRequest;
        }

        public async Task<ServiceResponse<string>> GetImageUrl(string userIdentifier)
        {
            var serviceResponse = new ServiceResponse<string>();

            string lastCharOfUserIdentifier = userIdentifier.TrimEnd().Last().ToString();
            bool isLastCharInt = Int32.TryParse(lastCharOfUserIdentifier, out int lastCharIntValue);
            char[] userIdentifierCharArray = userIdentifier.ToCharArray();

            if (isLastCharInt && jsonServerArray.Contains(lastCharIntValue))
            {
                var imageResponse = await jSONServerRequest.GetImageByLastDigitOfUserIdentifierAsync(lastCharIntValue);
                serviceResponse.Data = imageResponse.Url;
            }
            else if (isLastCharInt && sqliteArray.Contains(lastCharIntValue))
            {
                var imageResponse = await imageRepository.GetImageByIdAsync(lastCharIntValue);
                serviceResponse.Data = imageResponse.Url;
            }
            else if (userIdentifierCharArray.Intersect(vowelCharArray).Count() > 0)
            {
                serviceResponse.Data = "https://api.dicebear.com/8.x/pixel-art/png?seed=vowel&size=150";
            }
            else if (!userIdentifier.Trim().All(c => char.IsLetterOrDigit(c)))
            {
                Random random = new Random();
                int randomNumber = random.Next(1, 6);
                serviceResponse.Data = $"https://api.dicebear.com/8.x/pixel-art/png?seed={randomNumber}&size=150";
            }
            else
            {
                serviceResponse.Data = "https://api.dicebear.com/8.x/pixel-art/png?seed=default&size=150";
            }

            return serviceResponse;
        }
    }
}