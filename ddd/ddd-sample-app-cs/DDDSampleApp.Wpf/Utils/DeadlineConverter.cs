namespace DDDSampleApp.Wpf.Utils
{
  public static class DeadlineConverter
  {
    public static string ToDisplayDate(this DateTime? date)
    {
      if (date == null)
      {
        return string.Empty;
      }

      return ((DateTime)date).ToString("MM/dd");
    }
  }
}
