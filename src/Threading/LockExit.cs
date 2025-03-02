namespace Icod.Threading { 

	/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.LockExit"]/member[@name=""]/*'/>
	[Icod.Author( "Timothy J. ``Flytrap\'\' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	[Icod.LgplLicense]
	internal sealed class LockExit : System.IDisposable { 

		#region fields
		private Icod.Threading.LockExitHandler myExit;
		#endregion fields


		#region .ctor
		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.LockExit"]/member[@name="#ctor"]/*'/>
		public LockExit( Icod.Threading.LockExitHandler exit ) { 
			myExit = exit ?? throw new System.ArgumentNullException( nameof( exit ) );
			System.Runtime.CompilerServices.RuntimeHelpers.PrepareDelegate( myExit );
		}
		#endregion .ctor


		#region methods
		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.ISynchronousLock"]/member[@name="Exit"]/*'/>
		public void Dispose() { 
			this.Dispose( true );
			System.GC.SuppressFinalize( this );
		}

		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.ISynchronousLock"]/member[@name="Exit"]/*'/>
		private void Dispose( System.Boolean disposing ) { 
			if ( true == disposing ) { 
				System.Threading.Thread.BeginCriticalRegion();
				if ( null != myExit ) { 
					myExit();
					myExit = null;
				}
				System.Threading.Thread.EndCriticalRegion();
			}
		}
		#endregion methods

	}

}