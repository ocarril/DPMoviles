using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using slnWcfRestServiceParking.Dominio;

namespace slnWcfRestServiceParking.Persistencia
{
    public class ParkingLotDAO
    {
        private string cadenaConexion = null;

        public ParkingLotDAO()
        {
            cadenaConexion = UtilConexion.ObtenerConexion();
        }

        public List<ParkingLot> getParkingLots()
        {
            List<ParkingLot> lstParkingLot = new List<ParkingLot>();
            try
            {
                using (ParkingDataClassesDataContext SQLDC = new ParkingDataClassesDataContext(cadenaConexion))
                {
                    var parkingLot = from pl in SQLDC.parkingLots
                                     join pv in SQLDC.providers
                                     on pl.providerID equals pv.providerID
                                     join us in SQLDC.users
                                     on pv.userID equals us.userID
                                     join dt in SQLDC.disctricts
                                     on pl.districtId equals dt.districtId
                                     join pr in SQLDC.provinces
                                     on dt.provinceId equals pr.provinceId
                                     join dp in SQLDC.departments
                                     on pr.departmentId equals dp.departmentId
                                     select new
                                     {
                                         pl.address,
                                         pl.closeTime,
                                         pl.description,
                                         pl.disctrict,
                                         pl.districtId,
                                         pl.latitude,
                                         pl.LocalPhone,
                                         pl.longitud,
                                         pl.name,
                                         pl.openTime,
                                         pl.parkingLotID,
                                         pl.parkingSpaces,
                                         pl.priceHour,
                                         pl.provider,
                                         pl.providerID,
                                         pl.status,
                                         pl.urlPicture,
                                     };

                    foreach (var item in parkingLot)
                    {
                        ParkingLot objParkingLot = new ParkingLot();
                        
                        objParkingLot.address = item.address;
                        objParkingLot.closeTime = item.closeTime;
                        objParkingLot.description= item.description;
                        objParkingLot.districtId = item.districtId;
                        objParkingLot.latitude = item.latitude;
                        objParkingLot.LocalPhone=item.LocalPhone;
                        objParkingLot.longitud = item.longitud;
                        objParkingLot.name = item.name;
                        objParkingLot.openTime = item.openTime;
                        objParkingLot.parkingLotID = item.parkingLotID;
                        objParkingLot.priceHour = item.priceHour;
                        objParkingLot.providerID = item.providerID;
                        objParkingLot.status = item.status;
                        objParkingLot.urlPicture = item.urlPicture;
                        objParkingLot.objDisctrict = new Disctrict
                        {
                            disctrictId = item.disctrict.districtId,
                            name = item.disctrict.name,
                            provinceId = item.disctrict.provinceId,
                            objProvince = new Province
                            {
                                name = item.disctrict.province.name,
                                objDepartment = new Department
                                {
                                     name= item.disctrict.province.department.name
                                }
                            }
                        };
                        objParkingLot.objProvider = new Provider
                        {
                            providerID = item.provider.providerID,
                            status = item.provider.status,
                            userID = item.provider.userID
                        };
                        objParkingLot.lstParkingSpace = getParkingSpace(item.parkingLotID);
                        lstParkingLot.Add(objParkingLot);
                    }
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstParkingLot;
        }

        public ParkingLot getParkingLot(string parkingLotID)
        {
            ParkingLot objParkingLot = null;
            try
            {
                using (ParkingDataClassesDataContext SQLDC = new ParkingDataClassesDataContext(cadenaConexion))
                {
                    var parkingLot = from pl in SQLDC.parkingLots
                                     join pv in SQLDC.providers
                                     on pl.providerID equals pv.providerID
                                     join us in SQLDC.users
                                     on pv.userID equals us.userID
                                     join dt in SQLDC.disctricts
                                     on pl.districtId equals dt.districtId
                                     join pr in SQLDC.provinces
                                     on dt.provinceId equals pr.provinceId
                                     join dp in SQLDC.departments
                                     on pr.departmentId equals dp.departmentId
                                     where pl.parkingLotID == (string.IsNullOrEmpty(parkingLotID) ? 0 : Convert.ToInt32(parkingLotID))
                                     select new
                                     {
                                         pl.address,
                                         pl.closeTime,
                                         pl.description,
                                         pl.disctrict,
                                         pl.districtId,
                                         pl.latitude,
                                         pl.LocalPhone,
                                         pl.longitud,
                                         pl.name,
                                         pl.openTime,
                                         pl.parkingLotID,
                                         //pl.parkingSpaces,
                                         pl.priceHour,
                                         pl.provider,
                                         pl.providerID,
                                         pl.status,
                                         pl.urlPicture,
                                     };

                    foreach (var item in parkingLot)
                    {
                        objParkingLot = new ParkingLot();

                        objParkingLot.address = item.address;
                        objParkingLot.closeTime = item.closeTime;
                        objParkingLot.description = item.description;
                        objParkingLot.districtId = item.districtId;
                        objParkingLot.latitude = item.latitude;
                        objParkingLot.LocalPhone = item.LocalPhone;
                        objParkingLot.longitud = item.longitud;
                        objParkingLot.name = item.name;
                        objParkingLot.openTime = item.openTime;
                        objParkingLot.parkingLotID = item.parkingLotID;
                        objParkingLot.priceHour = item.priceHour;
                        objParkingLot.providerID = item.providerID;
                        objParkingLot.status = item.status;
                        objParkingLot.urlPicture = item.urlPicture;
                        objParkingLot.objDisctrict = new Disctrict
                        {
                            disctrictId = item.disctrict.districtId,
                            name = item.disctrict.name,
                            provinceId = item.disctrict.provinceId,
                            objProvince = new Province
                            {
                                name = item.disctrict.province.name,
                                objDepartment = new Department
                                {
                                    name = item.disctrict.province.department.name
                                }
                            }
                        };
                        objParkingLot.objProvider = new Provider
                        {
                            providerID = item.provider.providerID,
                            status = item.provider.status,
                            userID = item.provider.userID
                        };
                        objParkingLot.lstParkingSpace = getParkingSpace(item.parkingLotID);
                    }
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objParkingLot;
        }
     
        private List<ParkingSpace> getParkingSpace(int parkingLotID)
        {
            List<ParkingSpace> lstParkingSpace = new List<ParkingSpace>();
            using (ParkingDataClassesDataContext SQLDC = new ParkingDataClassesDataContext(cadenaConexion))
            {
                var result = from pl in SQLDC.parkingSpaces
                             where pl.parkingLotID == parkingLotID

                             select pl;

                foreach (parkingSpace parkSpa in result)
                {
                    ParkingSpace objParkingSpace = new ParkingSpace();
                    objParkingSpace.parkingSpaceID = parkSpa.parkingSpaceID;
                    objParkingSpace.parkingLotID = parkSpa.parkingLotID;
                    objParkingSpace.shortName = parkSpa.shortName;
                    objParkingSpace.status = parkSpa.status;
                    lstParkingSpace.Add(objParkingSpace);
                }
            }
            
            return lstParkingSpace;
        }
    }
}