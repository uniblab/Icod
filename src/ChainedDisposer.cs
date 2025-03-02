namespace Icod {

	/// <include file='..\doc\Icod.xml' path='types/type[@name="Icod.ChainedDisposer"]/member[@name=""]/*'/>
	[Icod.LgplLicense]
	[Icod.Author( "Timothy J. ``Flytrap'' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	public sealed class ChainedDisposer : Icod.Pair<System.IDisposable>, System.IDisposable {

		#region fields
		private System.Boolean myIsDisposed = false;
		#endregion fields


		#region .ctor
		/// <include file='..\doc\Icod.xml' path='types/type[@name="Icod.ChainedDisposer"]/member[@name="#ctor(System.IDisposable,System.IDisposable)"]/*'/>
		public ChainedDisposer( System.IDisposable outer, System.IDisposable inner ) : base( inner, outer ) {
#if NET6_0_OR_GREATER
			System.ArgumentNullException.ThrowIfNull( outer, nameof( outer ) );
#else
			if ( null == outer ) {
				throw new System.ArgumentNullException( nameof( outer ) );
			}
#endif
#if NET6_0_OR_GREATER
			System.ArgumentNullException.ThrowIfNull( inner, nameof( inner ) );
#else
			if ( null == inner ) {
				throw new System.ArgumentNullException( nameof( inner ) );
			}
#endif
		}

		/// <include file='..\doc\Icod.xml' path='types/type[@name="Icod.ChainedDisposer"]/member[@name="#dtor"]/*'/>
		~ChainedDisposer() {
			this.Dispose( false );
		}
		#endregion .ctor


		#region methods
		/// <include file='..\doc\Icod.xml' path='types/type[@name="System.IDisposable"]/member[@name="Dispose"]/*'/>
		public void Dispose() {
			this.Dispose( true );
			System.GC.SuppressFinalize( this );
		}
		/// <include file='..\doc\Icod.xml' path='types/type[@name="System.IDisposable"]/member[@name="Dispose(System.Boolean)"]/*'/>
		private void Dispose( System.Boolean disposing ) {
			if ( true == disposing ) {
				System.Threading.Thread.BeginCriticalRegion();
				if ( !myIsDisposed ) {
					var second = this.Second;
					second?.Dispose();
					var first = this.First;
					first?.Dispose();
					myIsDisposed = true;
				}
				System.Threading.Thread.EndCriticalRegion();
			}
		}
		#endregion methods

	}

}