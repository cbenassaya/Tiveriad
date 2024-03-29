﻿namespace Tiveriad.Workflows.Core.Models;

public class Event
{
    public const string EventTypeActivity = "WorkflowCore.Activity";
    public string Id { get; set; }

    public string EventName { get; set; }

    public string EventKey { get; set; }

    public object EventData { get; set; }

    public DateTime EventTime { get; set; }

    public bool IsProcessed { get; set; }
}