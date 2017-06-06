var gulp = require("gulp");
var del = require('del');
var changed = require('gulp-changed');
var sourceContentPath = "content";
var destContentPath = "dist";
var browserSync = require('browser-sync');
var exec = require('child_process').exec;
var gutil = require('gulp-util');

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
            sourceContentPath + '/**/*.gif',
            sourceContentPath + '/**/fonts/*.*',
        ])
        .pipe(changed(destContentPath))
        .pipe(gulp.dest(destContentPath));
});


///
//
// Watch Section 
//
///

/**
 * Watch all
 */
gulp.task('watch', function () {
    //watch any file under /dist
    browserSync.init({
        server: "dist",
        port: 3470, //specify the port to be used by browserify 
        files: [ //specify the files to watch (use regex)
            './dist/**/*.*'
        ],
        injectChanges: true,
        logFileChanges: true,
        logLevel: 'debug',
        logPrefix: 'browser-sync', //name to display in console
        notify: true,
        reloadDelay: 100 //the delay to wait before reloading a file
    });

    //watch css, images and static js
    gulp.watch([sourceContentPath + '/**/*.css',
        sourceContentPath + '/**/*.js',
        sourceContentPath + '/**/*.jpg',
        sourceContentPath + '/**/*.gif'
    ], ['copy']);

    //watch cshtml razor templates and md files
    gulp.watch([
        sourceContentPath + '/**/*.cshtml',
        sourceContentPath + '/**/*.md'
    ], function () {
        gutil.log('cshtml/md files updated, rebuilding...');
        exec('npm run build-pages');
    });
});