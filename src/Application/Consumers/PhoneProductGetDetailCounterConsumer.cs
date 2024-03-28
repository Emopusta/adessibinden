using DotNetCore.CAP;
using System.Text.Json;

namespace Application.Consumers;
public class PhoneProductGetDetailCounterConsumer : ICapSubscribe
{
    [CapSubscribe("phone_product_details_queue_cap")]
    public static void Consumer(JsonElement phoneProduct)
    {
        Console.WriteLine(phoneProduct);
    }

}
