using System;
using SharedProject.Seedworks;

namespace SharedProject.Domain.Enum
{
	public class PaymentStatus :  Enumeration
    {
    public static PaymentStatus Pending = new PaymentStatus(1, nameof(Pending).ToLowerInvariant());
    public static PaymentStatus Completed = new PaymentStatus(2, nameof(Completed).ToLowerInvariant());
    public static PaymentStatus Failed = new PaymentStatus(3, nameof(Failed).ToLowerInvariant());


    public PaymentStatus(int id, string name)
        : base(id, name)
    {
    }

    public static IEnumerable<PaymentStatus> List() =>
        new[] { Pending, Completed, Failed };

    public static PaymentStatus FromName(string name)
    {
        var state = List()
            .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

        if (state == null)
        {
            throw new AppointMentDomainException($"Possible values for OrderStatus: {String.Join(",", List().Select(s => s.Name))}");
        }

        return state;
    }

    public static PaymentStatus From(int id)
    {
        var state = List().SingleOrDefault(s => s.Id == id);

        if (state == null)
        {
            throw new AppointMentDomainException($"Possible values for OrderStatus: {String.Join(",", List().Select(s => s.Name))}");
        }

        return state;
    }
}
}

