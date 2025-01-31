﻿namespace KHM.Models
{
	public class HistoryModel
	{
		public int LogId { get; set; }
		public string LogDate { get; set; }
		public string LogTime { get; set; }
		public string UserName { get; set; }
		public string PerformedAction { get; set; }
		public string Description { get; set; }
		public string ModifiedField { get; set; }
		public string OldValue { get; set; }
		public string NewValue { get; set; }
	}
}
