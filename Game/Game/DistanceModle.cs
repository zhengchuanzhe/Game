using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public  class DistanceModle
    {
        public DistanceModle ()
        {
            this.Id = 0;
            this.XEnd = 0;
            this.YEnd = 0;
            this.XStrate = 0;
            this.YStrate = 0;
        }
        /// <summary>
        /// 触点ID
        /// </summary>
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// 开始时X坐标
        /// </summary>
        private double  xStrate;
        public double XStrate
        {
            get { return xStrate; }
            set { xStrate = value; }
        }

        /// <summary>
        ///开始时Y点坐标
        /// </summary>
        private double yStrate;
        public double YStrate
        {
            get { return yStrate; }
            set { yStrate = value; }
        }

        /// <summary>
        /// x轴方向运动距离
        /// </summary>
        private double xEnd;
        public double XEnd
        {
            get { return xEnd; }
            set { xEnd = value; }
        }


        /// <summary>
        /// y轴方向运动距离
        /// </summary>
        private double yEnd;
        public double YEnd
        {
            get { return yEnd; }
            set { yEnd = value; }
        }

    }
}
