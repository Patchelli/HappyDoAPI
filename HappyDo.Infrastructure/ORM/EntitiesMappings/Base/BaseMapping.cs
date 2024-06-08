using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.Infrastructure.ORM.EntitiesMappings.Base
{
    public abstract class BaseMapping
    {
        private const string DefaultSchema = "HPD";
        protected string Schema { get; }

        protected BaseMapping() =>
            Schema = DefaultSchema;

        protected BaseMapping(string schema) =>
            Schema = schema;

    }
}
