namespace Icod.Threading { 

	/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.SynchronousLockBase"]/member[@name=""]/*'/>
	[Icod.LgplLicense]
	[Icod.Author( "Timothy J. ``Flytrap'' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	public abstract class SynchronousLockBase : Icod.Threading.ISynchronousLock { 

		#region internal classes
		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.SynchronousLockBase.NativeMethods"]/member[@name=""]/*'/>
		internal static class NativeMethods { 
			/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.SynchronousLockBase.NativeMethods"]/member[@name="SwitchToThread"]/*'/>
			[System.Runtime.InteropServices.DllImport( "kernel32.dll", ExactSpelling = true )]
			[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
			internal static extern System.Boolean SwitchToThread();
		}
		#endregion internal classes


		#region .ctor
		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.SynchronousLockBase"]/member[@name="#ctor"]/*'/>
		protected SynchronousLockBase() { 
		}

		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.SynchronousLockBase"]/member[@name="#dtor"]/*'/>
		[System.Runtime.ConstrainedExecution.PrePrepareMethod]
		~SynchronousLockBase() { 
			this.Dispose( false );
		}
		#endregion .ctor


		#region methods
		void ISynchronousLock.Enter() { 
			this.Enter();
		}
		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.ISynchronousLock"]/member[@name="Enter"]/*'/>
		public abstract void Enter();

		void ISynchronousLock.Exit() { 
			this.Exit();
		}
		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.ISynchronousLock"]/member[@name="Exit"]/*'/>
		public abstract void Exit();

		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.SynchronousLockBase"]/member[@name="Spin"]/*'/>
		public static void Spin() { 
			Icod.Threading.SynchronousLockBase.Spin( 1 );
		}
		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.SynchronousLockBase"]/member[@name="Spin(System.Int32)"]/*'/>
		public static void Spin( System.Int32 count ) { 
			if ( count <= 0 ) { 
				count = 1;
			}
			if ( 1 == System.Environment.ProcessorCount ) { 
				for ( System.Int32 i = 0; i < count; i++ ) { 
					Icod.Threading.UserLock.NativeMethods.SwitchToThread();
				}
			} else { 
				System.Threading.Thread.SpinWait( count << 1 );
			}
		}

		void System.IDisposable.Dispose() { 
			this.Dispose();
		}
		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.SynchronousLockBase"]/member[@name="Dispose"]/*'/>
		public void Dispose() { 
			this.Dispose( true );
			System.GC.SuppressFinalize( this );
		}

		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.SynchronousLockBase"]/member[@name="Dispose(System.Boolean)"]/*'/>
		protected abstract void Dispose( System.Boolean disposing );
		#endregion methods

	}

}