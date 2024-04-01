using DotNetCore.CAP.Internal;

namespace Core.EventBus.Attributes;

public class CustomCapSubscribeAttribute : TopicAttribute
{
    public CustomCapSubscribeAttribute(Type name, bool isPartial = false) : base(name.Name, isPartial)
    {

    }

    public override string ToString()
    {
        return base.Name;
    }
}
