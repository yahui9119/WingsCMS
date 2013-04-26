using System;
using Omu.ValueInjecter;

namespace Wings.UI.Mappers
{
    public class NullablesToNormal : ConventionInjection
    {
        protected override bool Match(ConventionInfo c)
        {
            return c.SourceProp.Name == c.TargetProp.Name &&
                   Nullable.GetUnderlyingType(c.SourceProp.Type) == c.TargetProp.Type;
        }
    }
}