var gulp = require("gulp");
var del = require('del');
var changed = require('gulp-changed');
var sourceContentPath = "content";
var destContentPath = "dist";
var browserSync = require('browser-sync');
var exec = require('child_process').exec;
var gutil = require('gulp-util');
var cleanCSS = require('gulp-clean-css');
var uglify = require('gulp-uglify');
var concat = require('gulp-concat');
var pump = require('pump');


///
//
// Clean Section
//
///

/**
 * Clean dist
 */
gulp.task('clean', function () {
    return del([destContentPath + '/**', '!' + destContentPath]);
});


///
//
// Build Section
//
///

/**
 * Build Prod, uglify/minify js, css files
 */
gulp.task('build-prod', [
    'build-prod-css-vendor',
    'build-prod-css-main',
    'build-prod-js-vendor',
    'build-prod-js-main',
    'copy-assets'
]);

gulp.task('build-prod-css-vendor', function (cb) {
    //minify/bundle css files
    pump([
        gulp.src([
            sourceContentPath + '/**/css/lib/*.css',
            sourceContentPath + '/**/font-awesome.min.css'
        ]),
        cleanCSS(),
        concat('vendor.css'),
        gulp.dest(destContentPath)
    ], cb);
});

gulp.task('build-prod-css-main', function (cb) {
    //minify/bundle css files
    pump([
        gulp.src([
            sourceContentPath + '/**/home.css',
            sourceContentPath + '/**/site.css'
        ]),
        cleanCSS(),
        gulp.dest(destContentPath)
    ], cb);
});

gulp.task('build-prod-js-vendor', function (cb) {
    //uglify/bundle js files
    pump([
        gulp.src(sourceContentPath + '/**/lib/*.js'),
        uglify(),
        concat('vendor.js'),
        gulp.dest(destContentPath)
    ], cb);
});

gulp.task('build-prod-js-main', function (cb) {
    //uglify/bundle js files
    pump([
        gulp.src([
            sourceContentPath + '/**/home.js',
        ]),
        uglify(),
        gulp.dest(destContentPath)
    ], cb);
});

/**
 * END Build Prod
 */




/**
 * Build all
 */
gulp.task('build', ['copy-js-css', 'copy-assets']);

/**
 * Copy css, images and static js
 */

gulp.task('copy-js-css', function () {
    return gulp.src([sourceContentPath + '/**/*.css',
            sourceContentPath + '/**/*.js'
        ])
        .pipe(changed(destContentPath))
        .pipe(gulp.dest(destContentPath));
});

gulp.task('copy-assets', function () {
    return gulp.src([
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
    ], ['build']);

    //watch cshtml razor templates and md files
    gulp.watch([
        sourceContentPath + '/**/*.cshtml',
        sourceContentPath + '/**/*.md'
    ], function () {
        gutil.log('cshtml/md files updated, rebuilding...');
        exec('npm run build-pages');
    });
});