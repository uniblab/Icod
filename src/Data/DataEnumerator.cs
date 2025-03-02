namespace Icod.Data { 

	/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.DataEnumerator`1"]/member[@name=""]/*'/>
	[Icod.Author( "Timothy J. ``Flytrap\'\' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	[Icod.LgplLicense]
	public class DataEnumerator<T> : IDataEnumerator<T> where T : IDataReadable, new() { 

		#region fields
		private System.Boolean disposed;
		private readonly System.Data.IDbCommand myCommand;
		private System.Data.IDataReader myReader;
		private readonly System.Data.CommandBehavior myBehaviour;
		#endregion fields


		#region .ctor
		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.DataEnumerator`1"]/member[@name="#ctor(System.Data.Common.DbCommand)"]/*'/>
		internal DataEnumerator( System.Data.IDbCommand command ) : this( command, System.Data.CommandBehavior.SingleResult ) { 
		}

		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.DataEnumerator`1"]/member[@name="#ctor(System.Data.Common.DbCommand,System.Data.CommandBehavior)"]/*'/>
		internal DataEnumerator( System.Data.IDbCommand command, System.Data.CommandBehavior behaviour ) : this() {
			myCommand =  command ?? throw new System.InvalidOperationException();
			myBehaviour = behaviour;
			myReader = command.ExecuteReader( myBehaviour );
		}

		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.DataEnumerator`1"]/member[@name="#ctor"]/*'/>
		protected DataEnumerator() { 
			disposed = false;
		}

		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.DataEnumerator`1"]/member[@name="Finalize"]/*'/>
		~DataEnumerator() { 
			this.Dispose( false );
		}
		#endregion .ctor


		#region properties
		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.DataEnumerator`1"]/member[@name="Current"]/*'/>
		System.Object System.Collections.IEnumerator.Current { 
			get { 
				return ((System.Collections.Generic.IEnumerator<T>)this).Current;
			}
		}

		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.DataEnumerator`1"]/member[@name="Current"]/*'/>
		public T Current { 
			get { 
				if ( ( null == myReader ) || myReader.IsClosed ) { 
					throw new System.InvalidOperationException( );
				} else { 
					T output = new T();
					output.ReadFrom( myReader );
					return output;
				}
			}
		}
		#endregion properties


		#region methods
		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.DataEnumerator`1"]/member[@name="MoveNext"]/*'/>
		public System.Boolean MoveNext() { 
			return myReader.Read();
		}

		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.DataEnumerator`1"]/member[@name="Reset"]/*'/>
		public void Reset() {
			myReader?.Dispose();
			if ( null == myCommand ) {
				throw new System.InvalidOperationException();
			}
			myReader = myCommand.ExecuteReader( myBehaviour );
		}

		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="System.IDisposable"]/member[@name="Dispose"]/*'/>
		public void Dispose() { 
			this.Dispose( true );
			System.GC.SuppressFinalize( this );
		}

		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="System.IDisposable"]/member[@name="Dispose(System.Boolean)"]/*'/>
		protected virtual void Dispose( System.Boolean disposing ) { 
			lock ( this ) { 
				if ( false == disposed ) {
					myReader?.Dispose();
					if ( disposing ) { 
						myReader = null;
					}
					disposed = true;
				}
			}
		}
		#endregion methods

	}

}