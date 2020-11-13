﻿using System;
using System.ComponentModel;
using Elsa.Converters;
using Newtonsoft.Json;

namespace Elsa.Models
{
    public class WorkflowContextOptions
    {
        [JsonConverter(typeof(TypeJsonConverter))]
        [TypeConverter(typeof(TypeTypeConverter))]
        public Type ContextType { get; set; } = default!;
        public WorkflowContextFidelity ContextFidelity { get; set; }
    }
}