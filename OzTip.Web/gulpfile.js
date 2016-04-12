var gulp = require("gulp");
var cssnano = require("gulp-cssnano");
var less = require("gulp-less");
var rename = require("gulp-rename");

gulp.task("styles", [], function() {
    return gulp.src("AssetsSrc/style.less")
        .pipe(less())
        .pipe(cssnano())
        .pipe(rename("style.min.css"))
        .pipe(gulp.dest("Assets/css/"));
});

gulp.task("default", [], function() {
    return gulp.watch("AssetsSrc/style.less", ["styles"] );
});