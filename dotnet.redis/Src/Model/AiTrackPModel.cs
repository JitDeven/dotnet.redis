using System;
using System.Data;
using System.Globalization;
using System.Runtime.Serialization;

namespace dotnet.redis.Model
{
    [Serializable]
	public class AiTrackModel
	{
        
  //      #region 私有属性
  //   //   private int _deviceID = 0;
  //   //   private DateTime _gPSTime = DateTime.Now;
  //   //   private string _wID = String.Empty;
  //   //   //private byte[] _transfer = ;
  //   //   private decimal _lon = 0.00M;
  //   //   private decimal _lat = 0.00M;
  //   //   private short _direction = 0;
  //   //   private short _speed = 0;
  //   //   private decimal _odometer = 0.00M;
  //   //   //private byte[] _aCCStatus = ;
  //   //   //private byte[] _lineStatus = ;
  //   //   //private byte[] _loStatus = ;
  //   //   private string _status = String.Empty;
  //   //   private DateTime _createTime = DateTime.Now;
  //   //   //private string _lockStatus = String.Empty;
  //   //   private string _location = String.Empty;
  //   //   private DeviceType _deviceType = DeviceType.VehicleGPS;
	 //   //private int _newDeviceType = 1;
	 //   //private long _taskID = 0;
  //      #endregion
        
  //      #region 公共属性
		///// <summary>
		///// 设备ID
		///// </summary>
		//public int DeviceID
  //      {
  //          get { return _deviceID; }
  //          set { _deviceID = value; }
  //      }

		///// <summary>
		///// GPS上报时间
		///// </summary>
		//public DateTime GPSTime
  //      {
  //          get { return _gPSTime; }
  //          set { _gPSTime = value; }
  //      }

		///// <summary>
		///// 中心识别码
		///// </summary>
		//public string WID
  //      {
  //          get { return _wID; }
  //          set { _wID = value; }
  //      }

  //      ///// <summary>
  //      ///// 传输类型,1TCP,2UDP
  //      ///// </summary>
  //      //public byte[] Transfer
  //      //{
  //      //    get { return _transfer; }
  //      //    set { _transfer = value; }
  //      //}

		///// <summary>
		///// 经度
		///// </summary>
		//public decimal Lon
  //      {
  //          get { return _lon; }
  //          set { _lon = value; }
  //      }

		///// <summary>
		///// 纬度
		///// </summary>
		//public decimal Lat
  //      {
  //          get { return _lat; }
  //          set { _lat = value; }
  //      }

		///// <summary>
		///// 方向
		///// </summary>
		//public short Direction
  //      {
  //          get { return _direction; }
  //          set { _direction = value; }
  //      }

		///// <summary>
		///// 速度
		///// </summary>
		//public short Speed
  //      {
  //          get { return _speed; }
  //          set { _speed = value; }
  //      }

		///// <summary>
		///// 里程
		///// </summary>
		//public decimal Odometer
  //      {
  //          get { return _odometer; }
  //          set { _odometer = value; }
  //      }

  //      ///// <summary>
  //      ///// ACC状态;0 无,1关,2开
  //      ///// </summary>
  //      //public byte[] ACCStatus
  //      //{
  //      //    get { return _aCCStatus; }
  //      //    set { _aCCStatus = value; }
  //      //}

  //      ///// <summary>
  //      ///// 天线状态;0无,1天线正常，2天线断开，3天线短路,4天线状态异常
  //      ///// </summary>
  //      //public byte[] LineStatus
  //      //{
  //      //    get { return _lineStatus; }
  //      //    set { _lineStatus = value; }
  //      //}

  //      ///// <summary>
  //      ///// 定位状态;0 无,1 1D,2 2D ,3 3D
  //      ///// </summary>
  //      //public byte[] LoStatus
  //      //{
  //      //    get { return _loStatus; }
  //      //    set { _loStatus = value; }
  //      //}

		///// <summary>
		///// 设备状态
		///// </summary>
		//public string Status
  //      {
  //          get { return _status; }
  //          set { _status = value; }
  //      }

		///// <summary>
		///// 创建时间
		///// </summary>
		//public DateTime CreateTime
  //      {
  //          get { return _createTime; }
  //          set { _createTime = value; }
  //      }

  //      ///// <summary>
  //      ///// 子锁状态标识
  //      ///// </summary>
  //      //public string LockStatus
  //      //{
  //      //    get { return _lockStatus; }
  //      //    set { _lockStatus = value; }
  //      //}

		///// <summary>
		///// 地理位置
		///// </summary>
		//public string Location
  //      {
  //          get { return _location; }
  //          set { _location = value; }
  //      }

  //      public DeviceType DeviceType
  //      {
  //          get { return _deviceType; }
  //          set { _deviceType = value; }
  //      }

	 //   public long TaskID
	 //   {
  //          get { return _taskID; }
  //          set { _taskID = value; }
	 //   }
  //      #endregion

  //      public int NewDeviceType {
  //          get { return _newDeviceType; }
  //          set { _newDeviceType = value; }
  //      }
  //      #region 构造函数
  //      public AiTrackModel()
  //      {}
  //      #endregion
        
  //      #region IDataReader构造器
  //      public AiTrackModel(IDataReader reader)
  //      {
  //          string columnName = String.Empty;
  //          for (var i = 0; i < reader.FieldCount; ++i)
  //          {
  //              if (reader.IsDBNull(i))
  //              {
  //                  continue;
  //              }
  //              columnName = reader.GetName(i).ToUpper(CultureInfo.InvariantCulture);
  //              switch (columnName)
  //              {
  //                  case "VEHICLEID":
  //                  case "DEVICEID":
  //                      _deviceID = reader.GetInt32(i);
  //                      break;
  //                  case "GPSTIME":
  //                      _gPSTime = reader.GetDateTime(i);
  //                      break;
  //                  case "WID":
  //                      _wID = reader.GetString(i);
  //                      break;
  //                  //case "TRANSFER":
  //                  //    _transfer = reader.GetBytes(i);
  //                  //    break;
  //                  case "LON":
  //                      _lon = reader.GetDecimal(i);
  //                      break;
  //                  case "LAT":
  //                      _lat = reader.GetDecimal(i);
  //                      break;
  //                  case "DIRECTION":
  //                      _direction = reader.GetInt16(i);
  //                      break;
  //                  case "SPEED":
  //                      _speed = reader.GetInt16(i);
  //                      break;
  //                  case "ODOMETER":
  //                      _odometer = reader.GetDecimal(i);
  //                      break;
  //                  //case "ACCSTATUS":
  //                  //    _aCCStatus = reader.GetBytes(i);
  //                  //    break;
  //                  //case "LINESTATUS":
  //                  //    _lineStatus = reader.GetBytes(i);
  //                  //    break;
  //                  //case "LOSTATUS":
  //                  //    _loStatus = reader.GetBytes(i);
  //                  //    break;
  //                  case "STATUS":
  //                      _status = reader.GetString(i);
  //                      break;
  //                  case "CREATETIME":
  //                      _createTime = reader.GetDateTime(i);
  //                      break;
  //                  //case "LOCKSTATUS":
  //                  //    _lockStatus = reader.GetString(i);
  //                  //    break;
  //                  case "LOCATION":
  //                  case "PLACENAME":
  //                      _location = reader.GetString(i);
  //                      break;
  //                  case "NEWDEVICETYPE":
  //                      _newDeviceType = reader.GetInt32(i);
  //                      break;
  //                  case "TASKID":
  //                      _taskID = reader.GetInt64(i);
  //                      break;
  //              }
  //          }
  //      }
  //      #endregion
        
	}
}