using API.DTOs;
using Desktop;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using Web.Models;

namespace Web
{
    public static class RequestHelper
    {
        public static RequestMaker instructorRequestMaker, departmentRequestMaker, branchRequestMaker;
        static RequestHelper()
        {
            instructorRequestMaker = new("Instructors");
            departmentRequestMaker = new("Departments");
            branchRequestMaker = new("Branches");
        }

        //Instructors 
        static public async Task<ResponseViewModel> GetInstructorsBtn()
        {
            var res = await instructorRequestMaker.MakeRequest(null, null, HttpMethod.Get, "");

            string contetnt = await res.Content.ReadAsStringAsync();

            return new()
            {
                Response = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(contetnt), Formatting.Indented)
            };
        }

        static public async Task<ResponseViewModel> GetInstructorBtn(int id)
        {
            var res = await instructorRequestMaker.MakeRequest(null, null, HttpMethod.Get, $"{id}");

            string contetnt = await res.Content.ReadAsStringAsync();
            return new()
            {
                Response = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(contetnt), Formatting.Indented)
            };
        }

        static public async Task<ResponseViewModel> PutInstructorBtn(string body)
        {
            try
            {
                var instructor = System.Text.Json.JsonSerializer.Deserialize(Encoding.UTF8.GetBytes(body), typeof(InstructorDTO));
                var res = await instructorRequestMaker.MakeRequest(instructor, typeof(InstructorDTO), HttpMethod.Put, "");

                string contetnt = await res.Content.ReadAsStringAsync();
                return new()
                {
                    Response = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(contetnt), Formatting.Indented)
                };
            }
            catch (Exception exc)
            {
                return new()
                {
                    Response = exc.ToString()
                };
            }
        }

        static public async Task<ResponseViewModel> PostInstructorBtn(string body)
        {
            try
            {
                var instructor = System.Text.Json.JsonSerializer.Deserialize(Encoding.UTF8.GetBytes(body), typeof(InstructorDTO));
                var res = await instructorRequestMaker.MakeRequest(instructor, typeof(InstructorDTO), HttpMethod.Post, "");

                string contetnt = await res.Content.ReadAsStringAsync();
                return new()
                {
                    Response = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(contetnt), Formatting.Indented)
                };
            }
            catch (Exception exc)
            {
                return new()
                {
                    Response = exc.ToString()
                };
            }
        }

        static public async Task<ResponseViewModel> DeleteInstructorBtn(int id)
        {

            var res = await instructorRequestMaker.MakeRequest(null, null, HttpMethod.Delete, $"{id}");

            string contetnt = await res.Content.ReadAsStringAsync();
            return new()
            {
                Response = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(contetnt), Formatting.Indented)
            };

        }

        //Branches
        static public async Task<ResponseViewModel> GetBranchesBtn()
        {
            var res = await branchRequestMaker.MakeRequest(null, null, HttpMethod.Get, "");

            string contetnt = await res.Content.ReadAsStringAsync();
            return new()
            {
                Response = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(contetnt), Formatting.Indented)
            };
        }

        static public async Task<ResponseViewModel> GetBranchBtn(int id)
        {

            var res = await branchRequestMaker.MakeRequest(null, null, HttpMethod.Get, $"{id}");

            string contetnt = await res.Content.ReadAsStringAsync();
            return new()
            {
                Response = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(contetnt), Formatting.Indented)
            };
        }

        static public async Task<ResponseViewModel> PutBranchBtn(string body)
        {
            try
            {
                var branch = System.Text.Json.JsonSerializer.Deserialize(Encoding.UTF8.GetBytes(body), typeof(BranchDTO));
                var res = await branchRequestMaker.MakeRequest(branch, typeof(BranchDTO), HttpMethod.Put, "");

                string contetnt = await res.Content.ReadAsStringAsync();
                return new()
                {
                    Response = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(contetnt), Formatting.Indented)
                };
            }
            catch (Exception exc)
            {
                return new()
                {
                    Response = exc.ToString()
                };
            }
        }

        static public async Task<ResponseViewModel> PostBranchBtn(string body)
        {
            try
            {
                var branch = System.Text.Json.JsonSerializer.Deserialize(Encoding.UTF8.GetBytes(body), typeof(BranchDTO));
                var res = await branchRequestMaker.MakeRequest(branch, typeof(BranchDTO), HttpMethod.Post, "");

                string contetnt = await res.Content.ReadAsStringAsync();
                return new()
                {
                    Response = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(contetnt), Formatting.Indented)
                };
            }
            catch (Exception exc)
            {
                return new()
                {
                    Response = exc.ToString()
                };
            }
        }

        static public async Task<ResponseViewModel> DeleteBranchBtn(int id)
        {

            var res = await branchRequestMaker.MakeRequest(null, null, HttpMethod.Delete, $"{id}");

            string contetnt = await res.Content.ReadAsStringAsync();
            return new()
            {
                Response = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(contetnt), Formatting.Indented)
            };

        }

        //Departments
        static public async Task<ResponseViewModel> GetDepartmentsBtn()
        {
            var res = await departmentRequestMaker.MakeRequest(null, null, HttpMethod.Get, "");

            string contetnt = await res.Content.ReadAsStringAsync();
            return new()
            {
                Response = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(contetnt), Formatting.Indented)
            };
        }

        static public async Task<ResponseViewModel> GetDepartmentsDetailedBtn()
        {
            var res = await departmentRequestMaker.MakeRequest(null, null, HttpMethod.Get, "Detailed");

            string contetnt = await res.Content.ReadAsStringAsync();
            return new()
            {
                Response = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(contetnt), Formatting.Indented)
            };
        }

        static public async Task<ResponseViewModel> GetDepartmentBtn(int id)
        {
            var res = await departmentRequestMaker.MakeRequest(null, null, HttpMethod.Get, $"{id}");

            string contetnt = await res.Content.ReadAsStringAsync();
            return new()
            {
                Response = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(contetnt), Formatting.Indented)
            };

        }

        static public async Task<ResponseViewModel> GetDepartmentDetailedBtn(int id)
        {
            var res = await departmentRequestMaker.MakeRequest(null, null, HttpMethod.Get, $"Detailed/{id}");

            string contetnt = await res.Content.ReadAsStringAsync();
            return new()
            {
                Response = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(contetnt), Formatting.Indented)
            };

        }

        static public async Task<ResponseViewModel> PutDepartmentBtn(string body)
        {
            try
            {
                var department = System.Text.Json.JsonSerializer.Deserialize(Encoding.UTF8.GetBytes(body), typeof(DepartmentDTO));
                var res = await departmentRequestMaker.MakeRequest(department, typeof(DepartmentDTO), HttpMethod.Put, "");

                string contetnt = await res.Content.ReadAsStringAsync();
                return new()
                {
                    Response = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(contetnt), Formatting.Indented)
                };
            }
            catch (Exception exc)
            {
                return new()
                {
                    Response = exc.ToString()
                };
            }
        }

        static public async Task<ResponseViewModel> PostDepartmentBtn(string body)
        {
            try
            {
                var department = System.Text.Json.JsonSerializer.Deserialize(Encoding.UTF8.GetBytes(body), typeof(DepartmentDTO));
                var res = await departmentRequestMaker.MakeRequest(department, typeof(DepartmentDTO), HttpMethod.Post, "");

                string contetnt = await res.Content.ReadAsStringAsync();
                return new()
                {
                    Response = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(contetnt), Formatting.Indented)
                };
            }
            catch (Exception exc)
            {
                return new()
                {
                    Response = exc.ToString()
                };
            }
        }

        static public async Task<ResponseViewModel> DeleteDepartmentBtn(int id)
        {

            var res = await departmentRequestMaker.MakeRequest(null, null, HttpMethod.Delete, $"{id}");

            string contetnt = await res.Content.ReadAsStringAsync();
            return new()
            {
                Response = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(contetnt), Formatting.Indented)
            };
        }
    }
}
