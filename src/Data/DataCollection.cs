namespace Icod.Data {

	/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.DataCollection`1"]/member[@name=""]/*'/>
	[Icod.Author( "Timothy J. ``Flytrap\'\' Bruce" )]
	[Icod.ReportBugsTo( "mailto:uniblab@hotmail.com" )]
	[Icod.LgplLicense]
	public class DataCollection<T> : Icod.Data.DataEnumerable<T>, Icod.Data.IDataCollection<T> where T : Icod.Data.IDataReadable, new() {

		#region fields
		#endregion fields


		#region events
		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.DataCollection`1"]/member[@name="Adding"]/*'/>
		protected event AddingEventHandler<IDataCollection<T>, WriteEventArgs<T>> Adding;
		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.DataCollection`1"]/member[@name="Added"]/*'/>
		protected event AddedEventHandler<IDataCollection<T>, WriteEventArgs<T>> Added;

		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.DataCollection`1"]/member[@name="Clearing"]/*'/>
		protected event ClearingEventHandler<IDataCollection<T>, WriteEventArgs<T>> Clearing;
		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.DataCollection`1"]/member[@name="Cleared"]/*'/>
		protected event ClearedEventHandler<IDataCollection<T>, WriteEventArgs<T>> Cleared;

		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.DataCollection`1"]/member[@name="Contains"]/*'/>
		protected event ContainingEventHandler<IDataCollection<T>, ReadEventArgs<T>> Containing;
		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.DataCollection`1"]/member[@name="Contained"]/*'/>
		protected event ContainedEventHandler<IDataCollection<T>, ReadEventArgs<T>> Contained;

		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.DataCollection`1"]/member[@name="Counting"]/*'/>
		protected event CountingEventHandler<IDataCollection<T>, ReadEventArgs<T>> Counting;
		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.DataCollection`1"]/member[@name="Counted"]/*'/>
		protected event CountedEventHandler<IDataCollection<T>, ReadEventArgs<T>> Counted;

		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.DataCollection`1"]/member[@name="Removing"]/*'/>
		protected event RemovingEventHandler<IDataCollection<T>, WriteEventArgs<T>> Removing;
		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.DataCollection`1"]/member[@name="Removed"]/*'/>
		protected event RemovedEventHandler<IDataCollection<T>, WriteEventArgs<T>> Removed;
		#endregion events


		#region .ctor
		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.DataCollection`1"]/member[@name="#ctor(System.Data.Common.DbConnection)"]/*'/>
		public DataCollection( System.Data.Common.DbConnection connection ) : base( connection ) {
		}

		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.DataCollection`1"]/member[@name="#ctor(System.Data.Common.DbConnection,System.Data.CommandBehavior)"]/*'/>
		public DataCollection( System.Data.Common.DbConnection connection, System.Data.CommandBehavior commandBehaviour ) : base( connection, commandBehaviour ) {
		}

		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.DataCollection`1"]/member[@name="#ctor"]/*'/>
		private DataCollection() : base() {
		}
		#endregion .ctor


		#region properties
		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.IDataCountable`1"]/member[@name="Count"]/*'/>
		public System.Int32 Count {
			get {
				ReadEventArgs<T> arg = new ReadEventArgs<T>();
				this.Counting?.Invoke( this, arg );
				if ( arg.Cancel ) {
					return System.Int32.MinValue;
				}
				arg.Command.Connection = this.DataConnection;
				System.Int32 count = (System.Int32)arg.Command.ExecuteScalar();
				this.Counted?.Invoke( this, arg );
				arg.Command.Dispose();
				return count;
			}
		}

		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.DataCollection`1"]/member[@name="IsReadOnly"]/*'/>
		public System.Boolean IsReadOnly {
			get {
				throw new System.NotSupportedException();
			}
		}
		#endregion properties


		#region methods
		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.IDataAddable`1"]/member[@name="Add(`0)"]/*'/>
		public void Add( T item ) {
			WriteEventArgs<T> arg = new WriteEventArgs<T>( item );
			this.Adding?.Invoke( this, arg );
			if ( arg.Cancel ) {
				return;
			}
			arg.Command.Connection = this.DataConnection;
			_ = arg.Command.ExecuteNonQuery();
			this.Added?.Invoke( this, arg );
			arg.Command.Dispose();
		}

		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.IDataClearable`1"]/member[@name="Clear"]/*'/>
		public void Clear() {
			WriteEventArgs<T> arg = new WriteEventArgs<T>();
			this.Clearing?.Invoke( this, arg );
			if ( arg.Cancel ) {
				arg = null;
				return;
			}
			arg.Command.Connection = this.DataConnection;
			_ = arg.Command.ExecuteNonQuery();
			this.Cleared?.Invoke( this, arg );
			arg.Command.Dispose();
		}

		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.IDataExistential`1"]/member[@name="Contains(`0)"]/*'/>
		public System.Boolean Contains( T item ) {
			ReadEventArgs<T> arg = new ReadEventArgs<T>( item );
			this.Containing?.Invoke( this, arg );
			if ( arg.Cancel ) {
				return false;
			}
			arg.Command.Connection = this.DataConnection;
			System.Boolean output = ( 0 != (System.Int32)arg.Command.ExecuteScalar() );
			this.Contained?.Invoke( this, arg );
			arg.Command.Dispose();
			return output;
		}

		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.IDataCopyable`1"]/member[@name="CopyTo(`0[])"]/*'/>
		public void CopyTo( T[] array ) {
			this.CopyTo( array, 0 );
		}

		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.IDataCopyable`1"]/member[@name="CopyTo(`0[],System.Int32)"]/*'/>
		public void CopyTo( T[] array, System.Int32 arrayIndex ) {
#if NET8_0_OR_GREATER
			System.Collections.Generic.List<T> buffer;
#else
			System.Collections.Generic.ICollection<T> buffer;
#endif
			using ( IDataEnumerable<T> items = (IDataEnumerable<T>)this ) {
#if NET8_0_OR_GREATER
				buffer = [ .. items ];
#else
				buffer = new System.Collections.Generic.List<T>( items );
#endif
			}
			buffer.CopyTo( array, arrayIndex );
			buffer.Clear();
		}

		/// <include file='..\..\doc\Icod.Data.xml' path='types/type[@name="Icod.Data.IDataRemoveable`1"]/member[@name="Remove(`0[])"]/*'/>
		public System.Boolean Remove( T item ) {
			WriteEventArgs<T> arg = new WriteEventArgs<T>( item );
			this.Removing?.Invoke( this, arg );
			if ( arg.Cancel ) {
				return false;
			}
			arg.Command.Connection = this.DataConnection;
			System.Boolean output = ( 0 < arg.Command.ExecuteNonQuery() );
			this.Removed?.Invoke( this, arg );
			arg.Command.Dispose();
			return output;
		}
#endregion methods


		#region operators
		#endregion operators

	}

}