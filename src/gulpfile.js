var gulp = require("gulp");
var del = require('del');
var changed = require('gulp-changed');
var sourceContentPath = "../content";
var destContentPath = "bin/Debug/netcoreapp1.1/dist";
///
//
// Clean Section
//
///

/**
 * Clean wwwroot
 */
gulp.task('clean', function () {
    return del(destContentPath);
});


///
//
// Build Section
//
///

/**
 * Build all
 */
gulp.task('build', ['copy']);

/**
 * Copy css, images and static js
 */
gulp.task('copy', function () {
    return gulp.src([sourceContentPath + '/**/*.css',
            sourceContentPath + '/**/*.js',
            sourceContentPath + '/**/*.jpg',
            sourceContentPath + '/**/*.gif'
        ])
        .pipe(changed(destContentPath))
        .pipe(gulp.dest(destContentPath));
});