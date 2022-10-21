public class TimeMiddleware
{
    readonly RequestDelegate next; //Para invocar al siguiente middleware

    public TimeMiddleware(RequestDelegate nextRequest){
        next = nextRequest;
    }
    public async Task Invoke(HttpContext context){ //Toda la información del request
        //await next(context);// espera a que invoca al middleware que sigue, por eso agrega la hora al final después de que da respuesta
        if(context.Request.Query.Any(p=> p.Key == "time")){//Si contiene un key en la url https://localhost:7004/api/WeatherForecast/get?time le añade la hora
            await context.Response.WriteAsync(DateTime.Now.ToShortTimeString());
        }
        await next(context);//Primero añade la hora luego pasa al siguiente middleware por eso no muestra la respuesta y solo mnuestra la hora 
    }

}
public static class TimeMiddlewareExtension{ //para usar el middleware de tiempo
    public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder){
        return builder.UseMiddleware<TimeMiddleware>();
    }
}