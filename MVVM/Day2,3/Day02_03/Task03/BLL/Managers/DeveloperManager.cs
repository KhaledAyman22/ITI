using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Task03.BLL.UIModels;

namespace Task03.BLL.Managers
{
    public class DeveloperManager : IDeveloperManager
    {
        private record DeveloperDto(int Id, string Name);

        private readonly string url = "https://localhost:7273/api/developers";
        private static readonly HttpClient client = new();

        public async Task Add(Developer_UI student)
        {
            try
            {
                await client.PostAsJsonAsync($"{url}", new DeveloperDto(student.Id, student.Name));
            }
            catch (HttpRequestException e)
            {
                Trace.WriteLine($"Error: {e.Message}");
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                await client.DeleteAsync($"{url}/{id}");
            }
            catch (HttpRequestException e)
            {
                Trace.WriteLine($"Error: {e.Message}");
            }
        }

        public async Task<Developer_UI?> Get(int id)
        {
            try
            {
                DeveloperDto? dto = await client.GetFromJsonAsync<DeveloperDto?>($"{url}/{id}");

                if (dto == null) return null;

                return new Developer_UI()
                {
                    Id = dto.Id,
                    Name = dto.Name
                };
            }
            catch (HttpRequestException e)
            {
                Trace.WriteLine($"Error: {e.Message}");
                return null;
            }
        }

        public async Task<IEnumerable<Developer_UI>?> GetAll()
        {

            try
            {
                IEnumerable<DeveloperDto?>? dto = await client.GetFromJsonAsync<IEnumerable<DeveloperDto?>>($"{url}");

                if (dto == null) return null;

                return dto.Select(s => new Developer_UI()
                {
                    Id = s.Id,
                    Name = s.Name,
                });
            }
            catch (HttpRequestException e)
            {
                Trace.WriteLine($"Error: {e.Message}");
                return null;
            }
        }

        public async Task Update(Developer_UI student)
        {
            try
            {
                await client.PutAsJsonAsync($"{url}", student);
            }
            catch (HttpRequestException e)
            {
                Trace.WriteLine($"Error: {e.Message}");
            }
        }
    }
}
