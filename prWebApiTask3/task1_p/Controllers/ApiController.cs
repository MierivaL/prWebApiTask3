using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using NPoco;
using Nancy.Json;

namespace task1_p.Controllers
{
    [Route("[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ApiController : Controller
    {
        private readonly IRedisDBConn _redisDB;

        public ApiController(IRedisDBConn redisDBConn)
        {
            _redisDB = redisDBConn;
            redisDBConn.Connect("192.168.0.100:7001,password=prPassword");
        }

        [HttpGet]
        public async Task<ActionResult> Get(string Number)
        {
            DBConn dbConn = new DBConn();
            string key = "user_" + Number;
            if (_redisDB.IsDataAvailable(key))
                return Content(_redisDB.GetData(key), "application/json");
            User user = null;
            using (IDatabase db = dbConn.Connect())
            {
                user = (await db.FetchAsync<User>()).Find(x => x.PhoneNumber.Equals(Number));
                if (null != user)
                {
                    user.Appointments = (await db.FetchAsync<Appointment>("where UserId = @0", user.Id));
                }
                db.Dispose();
            }

            dbConn.Dispose(); dbConn = null;
            string str = new JavaScriptSerializer().Serialize(Json(user));
            _redisDB.SendData(key, str);
            return Content(str, "application/json");
        }

        // POST api
        [HttpPost]
        public async Task<ActionResult> Post([FromForm] string json)
        {
            DBConn dbConn = new DBConn();

            JsonAppointment info;
            //try
            //{
                info = System.Text.Json.JsonSerializer.Deserialize<JsonAppointment>(json);
                using (IDatabase db = dbConn.Connect())
                {
                    if (-1 == (await db.FetchAsync<User>()).FindIndex(x => x.PhoneNumber.Equals(info.PhoneNumber)))
                    {
                        User user = new User()
                        {
                            Firstname = info.Firstname,
                            Lastname = info.Lastname,
                            Patronymic = info.Patronymic,
                            PhoneNumber = info.PhoneNumber
                        };
                        await db.InsertAsync<User>(user);
                    }
                    Appointment appointment = new Appointment()
                    {
                        Date = DateTime.Now,
                        Comment = info.Comment,
                        UserId = (await db.FetchAsync<User>()).Find(x => x.PhoneNumber == info.PhoneNumber).Id
                    };
                    await db.InsertAsync<Appointment>(appointment);
                }
            //}
            //catch (Exception ex)
            //{
            //    return this.StatusCode(StatusCodes.Status400BadRequest, Json(new ErrorContainer(ex.Message)));
            //}
            dbConn.Dispose(); dbConn = null;
            return Redirect("~/Api?Number=" + info.PhoneNumber);
        }
    }
}
