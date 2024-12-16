namespace sa_it2030_fa24_fp_team_3_it2030_fa24.CustomMiddleware
{
    public class AliasMiddleware
    {
        private RequestDelegate next;

        public AliasMiddleware(RequestDelegate nextDelegate)
        {
            next = nextDelegate;
        }

        public async Task Invoke(HttpContext context) {
            if (context.Request.Path == "/")
            {
                context.Request.Path = "/Home/Home";
            }

            if (context.Request.Path == "/Home")
            {
                context.Request.Path = "/Home/Home";
            }


            if (context.Request.Path == "/Help")
            {
                context.Request.Path = "/Home/Help";
            }

            if (context.Request.Path == "/Characters/Zero") {
                context.Request.Path = "/Characters/Lelouch";
            }

            if (context.Request.Path == "/Zero")
            {
                context.Request.Path = "/Characters/Lelouch";
            }

            if (context.Request.Path == "/Organizations/Black-Knights")
            {
                context.Request.Path = "/Organizations/Black_Knights";
            }

            if (context.Request.Path == "/Black-Knights")
            {
                context.Request.Path = "/Organizations/Black_Knights";
            }
            
            if (context.Request.Path == "/create")
            {
                context.Request.Path = "/Characters/create";
            }

            if (context.Request.Path == "/all")
            {
                context.Request.Path = "/Characters/all";
            }

            /*
             format reminder
              if (context.Request.Path == "Path User entered")
            {
                context.Request.Path = "Path to direct user to.";
            }
             */

            await next(context);

        }

    }
}
