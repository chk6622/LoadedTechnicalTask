using LoadedTechnicalTask;
using LoadedTechnicalTask.Dto;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using Xunit;

namespace LoadedTechnicalTaskTest
{
    public class TimesheetControllerTest
    {
        private readonly HttpClient httpClient = null;
        public TimesheetControllerTest()
        {
            var server = new TestServer(WebHost.CreateDefaultBuilder().UseStartup<Startup>());
            httpClient = server.CreateClient();
        }

        [Fact]
        public async void ShouldClockIn()
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(new StaffMemberDto()
            {
                Name = "Tom"
            }));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await httpClient.PostAsync("/Staff", content);
            string responseBody = await response.Content.ReadAsStringAsync();
            StaffMemberDto staffMemberDto = JsonConvert.DeserializeObject<StaffMemberDto>(responseBody);

            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"/Timesheet/ClockIn/{staffMemberDto.Id}", null);

            Assert.Equal(HttpStatusCode.Created, httpResponseMessage.StatusCode);
        }

        [Fact]
        public async void ShouldNotClockInTwiceInARow()
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(new StaffMemberDto()
            {
                Name = "Tom"
            }));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await httpClient.PostAsync("/Staff", content);
            string responseBody = await response.Content.ReadAsStringAsync();
            StaffMemberDto staffMemberDto = JsonConvert.DeserializeObject<StaffMemberDto>(responseBody);

            await httpClient.PostAsync($"/Timesheet/ClockIn/{staffMemberDto.Id}", null);
            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"/Timesheet/ClockIn/{staffMemberDto.Id}", null);

            Assert.Equal(HttpStatusCode.BadRequest, httpResponseMessage.StatusCode);
        }

        [Fact]
        public async void ShouldClockOut()
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(new StaffMemberDto()
            {
                Name = "Tom"
            }));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await httpClient.PostAsync("/Staff", content);
            string responseBody = await response.Content.ReadAsStringAsync();
            StaffMemberDto staffMemberDto = JsonConvert.DeserializeObject<StaffMemberDto>(responseBody);

            await httpClient.PostAsync($"/Timesheet/ClockIn/{staffMemberDto.Id}", null);
            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"/Timesheet/ClockOut/{staffMemberDto.Id}", null);

            Assert.Equal(HttpStatusCode.Created, httpResponseMessage.StatusCode);
        }

        [Fact]
        public async void ShouldNotClockOutBeforeClockIn()
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(new StaffMemberDto()
            {
                Name = "Tom"
            }));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await httpClient.PostAsync("/Staff", content);
            string responseBody = await response.Content.ReadAsStringAsync();
            StaffMemberDto staffMemberDto = JsonConvert.DeserializeObject<StaffMemberDto>(responseBody);

            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"/Timesheet/ClockOut/{staffMemberDto.Id}", null);

            Assert.Equal(HttpStatusCode.BadRequest, httpResponseMessage.StatusCode);
        }

        [Fact]
        public async void ShouldUpdateTimesheet()
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(new StaffMemberDto()
            {
                Name = "Tom"
            }));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await httpClient.PostAsync("/Staff", content);
            string responseBody = await response.Content.ReadAsStringAsync();
            StaffMemberDto staffMemberDto = JsonConvert.DeserializeObject<StaffMemberDto>(responseBody);

            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync($"/Timesheet/ClockIn/{staffMemberDto.Id}", null);
            responseBody = await httpResponseMessage.Content.ReadAsStringAsync();
            TimesheetDto timesheetDto = JsonConvert.DeserializeObject<TimesheetDto>(responseBody);

            string newClockIn = "01/01/2021 10:00:00";
            string newClockOut = "01/01/2021 15:30:30";

            timesheetDto.ClockIn = newClockIn;
            timesheetDto.ClockOut = newClockOut;

            HttpContent timesheetContent = new StringContent(JsonConvert.SerializeObject(timesheetDto));
            timesheetContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            HttpResponseMessage httpResponseMessage1 = await httpClient.PutAsync("/Timesheet", timesheetContent);

            Assert.Equal(HttpStatusCode.Created, httpResponseMessage1.StatusCode);

            responseBody = await httpResponseMessage1.Content.ReadAsStringAsync();
            TimesheetDto timesheetDto1 = JsonConvert.DeserializeObject<TimesheetDto>(responseBody);

            Assert.Equal(newClockIn, timesheetDto1.ClockIn);
            Assert.Equal(newClockOut, timesheetDto1.ClockOut);

        }

    }
}
