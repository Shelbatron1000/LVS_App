using NUnit.Framework;
using Microsoft.Pex.Framework;
using System.Collections.Generic;
using Prototype;
using Microsoft.Pex.Framework.Generated;
// <copyright file="TeacherInfoTest.GetTeacherData.g.cs">Copyright ©  2014</copyright>
// <auto-generated>
// This file contains automatically generated tests.
// Do not modify this file manually.
// 
// If the contents of this file becomes outdated, you can delete it.
// For example, if it no longer compiles.
// </auto-generated>
using System;

namespace Prototype.Tests
{
    public partial class TeacherInfoTest
    {

[Test]
[PexGeneratedBy(typeof(TeacherInfoTest))]
public void GetTeacherData784()
{
    using (PexTraceListenerContext.Create())
    {
      List<TeacherInfo.Teacher> list;
      TeacherInfo teacherInfo;
      TeacherInfo.Teacher[] teachers = new TeacherInfo.Teacher[0];
      list =
        new List<TeacherInfo.Teacher>((IEnumerable<TeacherInfo.Teacher>)teachers);
      teacherInfo = new TeacherInfo();
      teacherInfo.elemTeachData = list;
      teacherInfo.secTeachData = (List<TeacherInfo.Teacher>)null;
      this.GetTeacherData(teacherInfo);
      PexAssert.IsNotNull((object)teacherInfo);
      PexAssert.IsNotNull((object)(teacherInfo.elemTeachData));
      PexAssert.AreEqual<int>(4, teacherInfo.elemTeachData.Capacity);
      PexAssert.AreEqual<int>(4, teacherInfo.elemTeachData.Count);
      PexAssert.IsNull((object)(teacherInfo.secTeachData));
    }
}

[Test]
[PexGeneratedBy(typeof(TeacherInfoTest))]
public void GetTeacherData47()
{
    using (PexTraceListenerContext.Create())
    {
      TeacherInfo teacherInfo;
      teacherInfo = new TeacherInfo();
      teacherInfo.elemTeachData = (List<TeacherInfo.Teacher>)null;
      teacherInfo.secTeachData = (List<TeacherInfo.Teacher>)null;
      this.GetTeacherData(teacherInfo);
      PexAssert.IsNotNull((object)teacherInfo);
      PexAssert.IsNull((object)(teacherInfo.elemTeachData));
      PexAssert.IsNull((object)(teacherInfo.secTeachData));
    }
}

[Test]
[PexGeneratedBy(typeof(TeacherInfoTest))]
public void GetTeacherData218()
{
    using (PexTraceListenerContext.Create())
    {
      List<TeacherInfo.Teacher> list;
      TeacherInfo teacherInfo;
      TeacherInfo.Teacher[] teachers = new TeacherInfo.Teacher[1];
      list =
        new List<TeacherInfo.Teacher>((IEnumerable<TeacherInfo.Teacher>)teachers);
      teacherInfo = new TeacherInfo();
      teacherInfo.elemTeachData = list;
      teacherInfo.secTeachData = (List<TeacherInfo.Teacher>)null;
      this.GetTeacherData(teacherInfo);
      PexAssert.IsNotNull((object)teacherInfo);
      PexAssert.IsNotNull((object)(teacherInfo.elemTeachData));
      PexAssert.AreEqual<int>(8, teacherInfo.elemTeachData.Capacity);
      PexAssert.AreEqual<int>(5, teacherInfo.elemTeachData.Count);
      PexAssert.IsNull((object)(teacherInfo.secTeachData));
    }
}

[Test]
[PexGeneratedBy(typeof(TeacherInfoTest))]
public void GetTeacherData169()
{
    List<TeacherInfo.Teacher> list;
    TeacherInfo teacherInfo;
    TeacherInfo.Teacher[] teachers = new TeacherInfo.Teacher[1];
    list = new List<TeacherInfo.Teacher>((IEnumerable<TeacherInfo.Teacher>)teachers);
    teacherInfo = new TeacherInfo();
    teacherInfo.elemTeachData = list;
    teacherInfo.secTeachData = list;
    this.GetTeacherData(teacherInfo);
    PexAssert.IsNotNull((object)teacherInfo);
    PexAssert.IsNotNull((object)(teacherInfo.elemTeachData));
    PexAssert.AreEqual<int>(16, teacherInfo.elemTeachData.Capacity);
    PexAssert.AreEqual<int>(9, teacherInfo.elemTeachData.Count);
    PexAssert.IsNotNull((object)(teacherInfo.secTeachData));
    PexAssert.IsTrue(object.ReferenceEquals
                         ((object)(teacherInfo.secTeachData), (object)(teacherInfo.elemTeachData)));
}
    }
}
