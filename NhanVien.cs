using System;
namespace QuanLyNhanVien
{
	public class NhanVien
	{

        public int maNV { get; set; }
        public string tenNV { get; set; }
        public DateTime ngaySinh { get; set; }
        public string gioiTinh { get; set; }
        public string diaChi { get; set; }
        public DateTime ngayVaoLam { get; set; }
        public string bangCap { get; set; }
        public string hinhThucNV { get; set; }
        public string loaiCV { get; set; }

        public NhanVien()
		{
		}

        public NhanVien(int maNV, string tenNV, DateTime ngaySinh, string gioTtinh, string diaChi, DateTime ngayVaoLam, string bangCap, string hinhThucNV, string loaiCV)
        {
            this.maNV = maNV;
            this.tenNV = tenNV;
            if(ngaySinh.Year >= 1930 && DateTime.Now.Year - ngaySinh.Year > 18)
            {
                this.ngaySinh = ngaySinh;
            }    else
            {
                Console.WriteLine("Năm sinh không hợp lệ");
                this.ngaySinh = new DateTime(1930,01,01);
            }

            this.gioiTinh = gioiTinh;

            this.diaChi = diaChi;
            this.ngayVaoLam = ngayVaoLam;
            if(bangCap != null)
            {
                this.bangCap = bangCap;
            }    else
            {
                this.bangCap = "THPT";
            }    
            if(hinhThucNV != null)
            {
                this.hinhThucNV = hinhThucNV;
            } else
            {
                this.hinhThucNV = "PartTime";
            }

            if(loaiCV != null)
            {
                this.loaiCV = loaiCV;
            }
            else
            {
                loaiCV = "Văn phòng";
            }  
        }

        public double timeWorking (int start, int end)
        {
            int TGLV = end - start;
            if (TGLV < 8)
            {
                if(8-TGLV <= 2)
                {
                    return 1;
                }  else if(8-TGLV > 2 && 8 - TGLV <= 2.5)
                {
                    return 0.5;
                }  else
                {
                    return 0;
                }
            }   else
            {
                double OT;
                return OT = 1 + ((TGLV - 8) * 2)/8;
            }
        }

        public double tinhPhep (string dieuKien, int ngayNghi, double luongCB)
        {
            double ngayPhep = 0;
            double luongPhat = 0;
            if(ngayVaoLam.Year - DateTime.Now.Year >= 12)
            {
                switch (dieuKien)
                {
                    case "binhthuong":
                        ngayPhep = 12;
                        break;
                    case "dacbiet":
                        ngayPhep = 14;
                        break;
                    case "nangnhoc":
                        ngayPhep = 16;
                        break;
                    default:
                        // Xử lý trường hợp điều kiện không hợp lệ
                        Console.WriteLine("Điều kiện không hợp lệ");
                        break;
                }
            } else
            {
                ngayPhep = ngayVaoLam.Year - DateTime.Now.Year;
            }

            if(ngayNghi - ngayPhep > 0 && ngayNghi - ngayPhep <=2)
            {
                luongPhat = 0.1 * luongCB;
            }
            else if(ngayNghi - ngayPhep > 2 && ngayNghi - ngayPhep <= 5)
            {
                luongPhat = 0.3 * luongCB;
            }
            else if (ngayNghi - ngayPhep > 5 && ngayNghi - ngayPhep <= 10)
            {
                luongPhat = 0.4 * luongCB;
            } else
            {
                luongPhat = 0.5 * luongCB;
            }

            if (ngayNghi < 0)
            {
                luongPhat = 0;
            }

            double tongLuong = luongCB - luongPhat;

            return tongLuong;
        }

        public double TinhPhuCap(string hocVi, string chucDanh, string phongBan, DateTime ngayVaoLam)
        {
            double phuCapHocVi = 0;
            double phuCapChucDanh = 0;
            double phuCapPhongBan = 0;
            double phuCapThamNien = 0;
            int thamnien = DateTime.Now.Year - ngayVaoLam.Year;

            // Phụ cấp theo học vị
            switch (hocVi.ToLower())
            {
                case "thpt":
                    phuCapHocVi = 0;
                    break;
                case "trungcap":
                    phuCapHocVi = 2000;
                    break;
                case "caodang":
                    phuCapHocVi = 4000;
                    break;
                case "daihoc":
                    phuCapHocVi = 6000;
                    break;
                case "thacsi":
                    phuCapHocVi = 8000;
                    break;
                case "tiensi":
                    phuCapHocVi = 10000;
                    break;
                default:
                    Console.WriteLine("Học vị không hợp lệ");
                    break;
            }

            //phụ cấp theo chức danh
            switch (chucDanh.ToLower())
            {
                case "nhanvien":
                    phuCapChucDanh = 2000;
                    break;
                case "photronphong":
                    phuCapChucDanh = 5000;
                    break;
                case "truongphong":
                    phuCapChucDanh = 10000;
                    break;
                case "phogiamdoc":
                    phuCapChucDanh = 12000;
                    break;
                case "giamdoc":
                    phuCapChucDanh = 15000;
                    break;
                default:
                    Console.WriteLine("Chức danh không hợp lệ");
                    break;
            }

            //phụ cấp theo phòng ban
            switch (phongBan.ToLower())
            {
                case "kinhdoanh":
                    phuCapPhongBan = 5000;
                    break;
                case "ketoan":
                    phuCapPhongBan = 5000;
                    break;
                case "bangiamdoc":
                    phuCapPhongBan = 20000;
                    break;
                case "hanhchinh":
                    phuCapPhongBan = 10000;
                    break;
                case "baove":
                    phuCapPhongBan = 1000;
                    break;
                default:
                    Console.WriteLine("Phòng ban không hợp lệ");
                    break;
            }

            //phụ cấp thep thâm niên
            if (thamnien == 0)
            {
                phuCapThamNien = 0;
            } else if(thamnien >= 1 && thamnien < 4)
            {
                phuCapThamNien = 1000;
            } else if ( thamnien >= 4 && thamnien < 8)
            {
                phuCapThamNien = 2000;
            } else if (thamnien >= 8 && thamnien <12)
            {
                phuCapThamNien = 3000;
            } else
            {
                phuCapThamNien = 5000;
            }

            double tongPhuCap = phuCapHocVi + phuCapChucDanh + phuCapPhongBan;

            return tongPhuCap;
        }

        public double TinhLuongPartTime(string loaiCV)
        {
            double luongPartTime = 0;

            switch (loaiCV.ToLower())
            {
                case "vanphong":
                    luongPartTime = 19000;
                    break;
                case "sanxuat":
                    luongPartTime = 20000;
                    break;
                default:
                    Console.WriteLine("Loại công việc không hợp lệ");
                    break;
            }

            return luongPartTime;
        }

        
        public double TinhLuongToanBo(string loaiCV, string hinhThucNV, string dieuKien, int ngayNghi, double luongThang, string hocVi, string chucDanh, string phongBan, DateTime ngayVaoLam)
        {
            // Tính lương phụ cấp
            double phuCap = TinhPhuCap(hocVi, chucDanh, phongBan, ngayVaoLam);

            // Tính lương phép
            double luongPhep = tinhPhep(dieuKien, ngayNghi, luongThang);


            double tongLuong = 0;

            if (hinhThucNV == "PartTime")
            {
                tongLuong = TinhLuongPartTime(loaiCV);
            }   else
            {
                tongLuong = luongThang + phuCap + luongPhep;
            } 


            return tongLuong;
        }

    }
}

