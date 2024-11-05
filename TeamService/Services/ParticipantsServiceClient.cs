using TeamService.Services.Contracts;

namespace TeamService.Services
{
    public class ParticipantsServiceClient : IParticipantsServiceClient
    {
        private readonly HttpClient _httpClient;

        public ParticipantsServiceClient(HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CheckParticipantsExists(ICollection<int> participantIds)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/participants/validate", participantIds);

                if (response.IsSuccessStatusCode)
                {
                    var isValid = await response.Content.ReadFromJsonAsync<bool>();
                    return isValid;
                }else
                    return false;
            }
            catch (Exception ex) 
            {
                throw new Exception("Unable to connect to participant service");
            }
        }
    }
}
