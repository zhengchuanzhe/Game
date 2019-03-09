using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public  class DirectionJudge
    {
        public DirectionJudge ()
        { }
      #region 竖直界面判断滑动方向
        /// <summary>
        /// 竖直界面判断滑动方向
        /// </summary>
        /// <param name="xDistance">x方向上运动距离</param>
        /// <param name="yDistance">y方向上运动距离</param>
        /// <returns>-1为出错，1为向左，2为向右，3为向上，4为向下</returns>
        public int Direction(double xDistance, double yDistance)
        {
            try
            {
                  if (Math.Abs(xDistance)>Math .Abs (yDistance ))
                  {
                      if (xDistance<0)
                      {
                        return 1;
                       }
                      else
                      {
                          return 2;
                      }
                   }
                  else
                  {
                      if (yDistance <0)
                      {
                          return 3;
                      }
                      else
                      {
                          return 4;
                      }
                  }
            }
            catch (Exception)
            {
                return -1;
            }
        }
	  #endregion

      #region 水平界面判断滑动方向
        public int DirectionLevel(double xDistance, double yDistance)
        {
            try
            {
                if (Math.Abs(xDistance) > Math.Abs(yDistance))
                {
                    if (xDistance <0)
                    {
                        return 4;
                    }
                    else
                    {
                        return 3;
                    }
                }
                else
                {
                    if (yDistance < 0)
                    {
                        return 1;
                    }
                    else
                    {
                        return 2;
                    }
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }
      #endregion

    }
}
