﻿using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLNS
{
    public class KyCongChiTiet_BUS
    {
        BTLMonLTTQEntities db = new BTLMonLTTQEntities();

        public List<dynamic> getList(int makycong)
        {
            return (from kc in db.KYCONGCHITIETs
                    join nv in db.NhanViens on kc.MaNhanVien equals nv.MaNhanVien
                    where kc.MAKYCONG == makycong
                    orderby nv.MaNhanVien
                    select new
                    {
                        MANV = kc.MaNhanVien,
                        HOTEN = nv.HoTen,
                        kc.D1,
                        kc.D2,
                        kc.D3,
                        kc.D4,
                        kc.D5,
                        kc.D6,
                        kc.D7,
                        kc.D8,
                        kc.D9,
                        kc.D10,
                        kc.D11,
                        kc.D12,
                        kc.D13,
                        kc.D14,
                        kc.D15,
                        kc.D16,
                        kc.D17,
                        kc.D18,
                        kc.D19,
                        kc.D20,
                        kc.D21,
                        kc.D22,
                        kc.D23,
                        kc.D24,
                        kc.D25,
                        kc.D26,
                        kc.D27,
                        kc.D28,
                        kc.D29,
                        kc.D30,
                        kc.D31
                    }).ToList<dynamic>();
        }

        public bool kiemTraPhatSinhKyCong(int makycong)
        {
            var kcct = db.KYCONGCHITIETs.Where(x => x.MAKYCONG == makycong).ToList();
            if (kcct.Count == 0)
                return false;
            return true;
        }

        public void phatSinhKyCongChiTiet(int thang, int nam)
        {
            int makycong = nam * 100 + thang;
            
            // Xóa dữ liệu cũ nếu đã tồn tại
            var oldData = db.KYCONGCHITIETs.Where(x => x.MAKYCONG == makycong);
            if (oldData.Any())
            {
                db.KYCONGCHITIETs.RemoveRange(oldData);
                db.SaveChanges();
            }

            var lstNV = db.NhanViens.ToList();
            if (lstNV.Count == 0) return;

            foreach (var item in lstNV)
            {
                List<string> listDay = new List<string>();

                for (int j = 1; j <= GetDayNumber(thang, nam); j++)
                {
                    DateTime newDate = new DateTime(nam, thang, j);

                    switch (newDate.DayOfWeek.ToString())
                    {
                        case "Sunday":
                            listDay.Add("CN");
                            break;
                        case "Saturday":
                            listDay.Add("T7");
                            break;
                        default:
                            listDay.Add("X");
                            break;
                    }
                }

                // Đảm bảo đủ 31 ngày bằng cách thêm chuỗi rỗng
                while (listDay.Count < 31)
                {
                    listDay.Add("");
                }

                KYCONGCHITIET kycongchitiet = new KYCONGCHITIET
                {
                    MAKYCONG = makycong,
                    MaNhanVien = item.MaNhanVien,
                    D1 = listDay[0],
                    D2 = listDay[1],
                    D3 = listDay[2],
                    D4 = listDay[3],
                    D5 = listDay[4],
                    D6 = listDay[5],
                    D7 = listDay[6],
                    D8 = listDay[7],
                    D9 = listDay[8],
                    D10 = listDay[9],
                    D11 = listDay[10],
                    D12 = listDay[11],
                    D13 = listDay[12],
                    D14 = listDay[13],
                    D15 = listDay[14],
                    D16 = listDay[15],
                    D17 = listDay[16],
                    D18 = listDay[17],
                    D19 = listDay[18],
                    D20 = listDay[19],
                    D21 = listDay[20],
                    D22 = listDay[21],
                    D23 = listDay[22],
                    D24 = listDay[23],
                    D25 = listDay[24],
                    D26 = listDay[25],
                    D27 = listDay[26],
                    D28 = listDay[27],
                    D29 = listDay[28],
                    D30 = listDay[29],
                    D31 = listDay[30]
                };

                try
                {
                    db.KYCONGCHITIETs.Add(kycongchitiet);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception("Có lỗi xảy ra trong quá trình phát sinh kỳ công: " + ex.Message);
                }
            }
        }

        private int GetDayNumber(int thang, int nam)
        {
            int dayNumber = 0;
            switch (thang)
            {
                case 2:
                    dayNumber = (nam % 4 == 0 && nam % 100 != 0) || nam % 400 == 0 ? 29 : 28;
                    break;

                case 4:
                case 6:
                case 9:
                case 11:
                    dayNumber = 30;
                    break;

                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    dayNumber = 31;
                    break;
            }

            return dayNumber;
        }
    }
}