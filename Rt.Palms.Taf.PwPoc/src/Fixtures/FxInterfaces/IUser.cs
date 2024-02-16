using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rt.Palms.Taf.PwPoc.src.Fixtures.FxInterfaces;

internal interface IUser
{
    void GetSAPUserFixture() { }
    void GetUserFindFixture() { }
    void GetUserFindNoProfileFoundFixture() { }
}
