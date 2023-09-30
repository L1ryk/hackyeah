﻿using WebAPI.Models.Paginations;
using WebAPI.Models.Responses.Courses;

namespace WebAPI.DataSource.Accessors.UniversityAccessors;

public interface ICourseAccessor
{
    Task<GetAllCoursesResponse> GetAllCoursesAsync( Pagination pagination );
    Task<GetAllCoursesResponse> GetCoursesAsync( GetCourses getCourses );
}