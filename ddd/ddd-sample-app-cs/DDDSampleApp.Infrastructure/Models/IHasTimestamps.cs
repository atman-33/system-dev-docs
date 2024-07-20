﻿namespace DDDSampleApp.Infrastructure;

internal interface IHasTimestamps
{
  DateTime? CreatedAt { get; set; }
  DateTime? UpdatedAt { get; set; }
}
