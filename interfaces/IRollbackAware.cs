namespace Netfox;

public interface IRollbackAware
{
	public void _rollback_tick(double delta, long tick, bool isFresh);
}
