namespace Icod {

	[Icod.LgplLicense]
	[Icod.Author( "Timothy J. ``Flytrap'' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	public sealed class ChainedDisposer : System.IDisposable {

		#region fields
		private readonly Icod.Pair<System.IDisposable> myPair;
		#endregion fields


		#region .ctor
		public ChainedDisposer( System.IDisposable outer, System.IDisposable inner ) : base() {
			if ( null == outer ) {
				throw new System.ArgumentNullException( "outer" );
			}
			if ( null == inner ) {
				throw new System.ArgumentNullException( "inner" );
			}
			myPair = new Pair<System.IDisposable>( inner, outer );
		}

		~ChainedDisposer() {
			this.Dispose( false );
		}
		#endregion .ctor


		#region methods
		public void Dispose() {
			this.Dispose( true );
			System.GC.SuppressFinalize( this );
		}
		private void Dispose( System.Boolean disposing ) {
			if ( true == disposing ) {
				System.Threading.Thread.BeginCriticalRegion();
				var second = myPair.Second;
				if ( null != second ) {
					second.Dispose();
				}
				var first = myPair.First;
				if ( null != first ) {
					first.Dispose();
				}
				System.Threading.Thread.EndCriticalRegion();
			}
		}
		#endregion methods

	}

}