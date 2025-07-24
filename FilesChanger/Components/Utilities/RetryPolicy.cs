namespace FilesChanger.Components.Utilities
{
    public class RetryPolicy
    {
        private readonly int _maxRetries;

        public RetryPolicy(int maxRetries)
        {
            _maxRetries = maxRetries;
        }

        public void Execute(Action action)
        {
            int attempt = 0;
            while (true)
            {
                try
                {
                    action();
                    return;
                }
                catch
                {
                    if (++attempt > _maxRetries)
                        throw new Exception("Maximum retry attempts exceeded.");
                }
            }
        }
    }
}
