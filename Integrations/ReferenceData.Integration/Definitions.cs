#region

using FluentValidation;
using MediatR;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Core.Abstractions.Services;
using Tiveriad.IdGenerators;
using Tiveriad.ReferenceData.Core.Entities;

#endregion

namespace ReferenceData.Integration;

[ReferenceDataRoute("skills")]
public class Skill : KeyValue { }

[ReferenceDataRoute("programmingLanguages")]
public class ProgrammingLanguage : KeyValue { }