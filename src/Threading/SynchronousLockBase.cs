using System.Security;

namespace Icod.Threading { 

	/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.SynchronousLockBase"]/member[@name=""]/*'/>
	[Icod.LgplLicense]
	[Icod.Author( "Timothy J. ``Flytrap'' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	public abstract partial class SynchronousLockBase : Icod.Threading.ISynchronousLock { 

		#region internal classes
		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.SynchronousLockBase.NativeMethods"]/member[@name=""]/*'/>
		internal static partial class NativeMethods {
			/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.SynchronousLockBase.NativeMethods"]/member[@name="SwitchToThread"]/*'/>
			[return: System.Runtime.InteropServices.MarshalAs( System.Runtime.InteropServices.UnmanagedType.Bool )]
#if NET7_0_OR_GREATER
			[System.Runtime.InteropServices.LibraryImport( "Kernel32.dll", EntryPoint = "SwitchToThread" )]
#else
			[System.Runtime.InteropServices.DllImport( "kernel32.dll", EntryPoint = "SwitchToThread" )]
#endif
			internal static
#if NET7_0_OR_GREATER
			partial
#else
			extern
#endif
			System.Boolean SwitchToThread();
		}
		#endregion internal classes


		#region .ctor
		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.SynchronousLockBase"]/member[@name="#ctor"]/*'/>
		protected SynchronousLockBase() { 
		}

		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.SynchronousLockBase"]/member[@name="#dtor"]/*'/>
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
					_ = Icod.Threading.UserLock.NativeMethods.SwitchToThread();
				}
			} else { 
				System.Threading.Thread.SpinWait( count << 1 );
			}
		}

		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="Icod.Threading.SynchronousLockBase"]/member[@name="Dispose"]/*'/>
		public void Dispose() { 
			this.Dispose( true );
			System.GC.SuppressFinalize( this );
		}

		/// <include file='..\..\doc\Icod.Threading.xml' path='types/type[@name="System.IDisposable"]/member[@name="Dispose(System.Boolean)"]/*'/>
		protected abstract void Dispose( System.Boolean disposing );
		#endregion methods

	}

}