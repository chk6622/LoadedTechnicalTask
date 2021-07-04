using LoadedTechnicalTask;
using LoadedTechnicalTask.Dto;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Xunit;

namespace LoadedTechnicalTaskTest
{
    public class StaffControllerTest
    {
        private readonly HttpClient httpClient = null;
        public StaffControllerTest()
        {
            var server = new TestServer(WebHost.CreateDefaultBuilder().UseStartup<Startup>());
            httpClient = server.CreateClient();
        }

        [Fact]
        public async void ShouldAddNewStaff()
        {
            StaffMemberDto staffMemberDto = new StaffMemberDto()
            {
                Name = "Tom"
            };
            HttpContent content = new StringContent(JsonConvert.SerializeObject(staffMemberDto));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await httpClient.PostAsync("/Staff", content);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            StaffMemberDto staffMemberDto1 = JsonConvert.DeserializeObject<StaffMemberDto>(responseBody);
            Assert.Equal(staffMemberDto.Name, staffMemberDto1.Name);
        }

        [Fact]
        public async void ShouldGetStaff()
        {
            StaffMemberDto staffMemberDto = new StaffMemberDto()
            {
                Name = "Tom"
            };
            HttpContent content = new StringContent(JsonConvert.SerializeObject(staffMemberDto));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await httpClient.PostAsync("/Staff", content);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            StaffMemberDto staffMemberDto1 = JsonConvert.DeserializeObject<StaffMemberDto>(responseBody);

            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync($"/Staff/{staffMemberDto1.Id}");
            httpResponseMessage.EnsureSuccessStatusCode();

            responseBody = await response.Content.ReadAsStringAsync();

            StaffMemberDto staffMemberDto2 = JsonConvert.DeserializeObject<StaffMemberDto>(responseBody);

            Assert.Equal(staffMemberDto1.Id, staffMemberDto2.Id);
            Assert.Equal(staffMemberDto1.Name, staffMemberDto2.Name);
        }

        [Fact]
        public async void ShouldGetAllStaffs()
        {
            StaffMemberDto staffMemberDto1 = new StaffMemberDto()
            {
                Name = "Tom"
            };
            HttpContent content1 = new StringContent(JsonConvert.SerializeObject(staffMemberDto1));
            content1.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await httpClient.PostAsync("/Staff", content1);
            response.EnsureSuccessStatusCode();

            StaffMemberDto staffMemberDto2 = new StaffMemberDto()
            {
                Name = "Kate"
            };
            HttpContent content2 = new StringContent(JsonConvert.SerializeObject(staffMemberDto2));
            content2.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            response = await httpClient.PostAsync("/Staff", content2);
            response.EnsureSuccessStatusCode();

            StaffMemberDto staffMemberDto3 = new StaffMemberDto()
            {
                Name = "Mary"
            };
            HttpContent content3 = new StringContent(JsonConvert.SerializeObject(staffMemberDto3));
            content3.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            response = await httpClient.PostAsync("/Staff", content3);
            response.EnsureSuccessStatusCode();


            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync($"/Staff");
            httpResponseMessage.EnsureSuccessStatusCode();

            string responseBody = await httpResponseMessage.Content.ReadAsStringAsync();

            List<StaffMemberDto> staffMemberDtoes = JsonConvert.DeserializeObject<List<StaffMemberDto>>(responseBody);

            Assert.True(staffMemberDtoes.Count > 0);
            Assert.True(staffMemberDtoes.Where(e => e.Name == "Tom").Any());
            Assert.True(staffMemberDtoes.Where(e => e.Name == "Kate").Any());
            Assert.True(staffMemberDtoes.Where(e => e.Name == "Mary").Any());
        }
    }

}
