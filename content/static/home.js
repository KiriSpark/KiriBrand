$(window).load(function () {
    //set a default timout for the loader animation
    //so people can see it
    setTimeout(function () {
        //hide the loader
        $(".se-pre-con").hide();
        //call page animation
        animateHeader();
        animateSections();
    }, 560);
});
//function to animate the header buttons
function animateHeader() {
    var delay = 100;
    $('.nav-item').each(function (index, item) {
        animateNavButton('#' + item.id, delay);
        delay += 150;
    });
}
//function to animate one particular button by its Id name
//using Velocity library
function animateNavButton(itemName, delay) {
    if (delay === void 0) { delay = 0; }
    $(itemName).velocity('transition.flipXIn', {
        delay: delay,
        opacity: 1,
        duration: 1000
    });
}
//this will animate sections inside the body
//using scrolReveal library
function animateSections() {
    var config = {
        duration: 300,
        delay: 600,
        distance: '200px',
        origin: 'right',
        easing: 'cubic-bezier(1, 1, 1, 1)'
    };
    var sr = window.sr = ScrollReveal();
    $('.animated').each(function (index, item) {
        sr.reveal(item, config);
    });
}

//# sourceMappingURL=data:application/json;charset=utf8;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbImhvbWUudHMiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IkFBSUEsQ0FBQyxDQUFDLE1BQU0sQ0FBQyxDQUFDLElBQUksQ0FBQztJQUNYLCtDQUErQztJQUMvQyxzQkFBc0I7SUFDdEIsVUFBVSxDQUFDO1FBQ1AsaUJBQWlCO1FBQ2pCLENBQUMsQ0FBQyxhQUFhLENBQUMsQ0FBQyxJQUFJLEVBQUUsQ0FBQztRQUN4QixxQkFBcUI7UUFDckIsYUFBYSxFQUFFLENBQUM7UUFDaEIsZUFBZSxFQUFFLENBQUM7SUFDdEIsQ0FBQyxFQUFFLEdBQUcsQ0FBQyxDQUFDO0FBRVosQ0FBQyxDQUFDLENBQUM7QUFFSCx3Q0FBd0M7QUFDeEM7SUFDSSxJQUFJLEtBQUssR0FBRyxHQUFHLENBQUM7SUFDaEIsQ0FBQyxDQUFDLFdBQVcsQ0FBQyxDQUFDLElBQUksQ0FBQyxVQUFVLEtBQUssRUFBRSxJQUFJO1FBQ3JDLGdCQUFnQixDQUFDLEdBQUcsR0FBRyxJQUFJLENBQUMsRUFBRSxFQUFFLEtBQUssQ0FBQyxDQUFDO1FBQ3ZDLEtBQUssSUFBSSxHQUFHLENBQUM7SUFDakIsQ0FBQyxDQUFDLENBQUM7QUFDUCxDQUFDO0FBQ0QsMERBQTBEO0FBQzFELHdCQUF3QjtBQUN4QiwwQkFBMEIsUUFBUSxFQUFFLEtBQVM7SUFBVCxzQkFBQSxFQUFBLFNBQVM7SUFDekMsQ0FBQyxDQUFDLFFBQVEsQ0FBQyxDQUFDLFFBQVEsQ0FBQyxvQkFBb0IsRUFBRTtRQUN2QyxLQUFLLEVBQUUsS0FBSztRQUNaLE9BQU8sRUFBRSxDQUFDO1FBQ1YsUUFBUSxFQUFFLElBQUk7S0FDakIsQ0FBQyxDQUFDO0FBQ1AsQ0FBQztBQUVELDRDQUE0QztBQUM1QywyQkFBMkI7QUFDM0I7SUFDSSxJQUFJLE1BQU0sR0FBRztRQUNULFFBQVEsRUFBRSxHQUFHO1FBQ2IsS0FBSyxFQUFFLEdBQUc7UUFDVixRQUFRLEVBQUUsT0FBTztRQUNqQixNQUFNLEVBQUUsT0FBTztRQUNmLE1BQU0sRUFBRSwwQkFBMEI7S0FFckMsQ0FBQztJQUVGLElBQU0sRUFBRSxHQUFJLE1BQWMsQ0FBQyxFQUFFLEdBQUcsWUFBWSxFQUFFLENBQUM7SUFDL0MsQ0FBQyxDQUFDLFdBQVcsQ0FBQyxDQUFDLElBQUksQ0FBQyxVQUFDLEtBQUssRUFBRSxJQUFJO1FBQzVCLEVBQUUsQ0FBQyxNQUFNLENBQUMsSUFBSSxFQUFFLE1BQU0sQ0FBQyxDQUFDO0lBQzVCLENBQUMsQ0FBQyxDQUFDO0FBQ1AsQ0FBQyIsImZpbGUiOiJob21lLmpzIiwic291cmNlc0NvbnRlbnQiOlsiLy9kZWNsYXJpbmcgZ2xvYmFsIGZ1bmN0aW9uIGFkZGVkIGJ5IHRoZSB1c2FnZVxyXG4vL29mIHNjcm9sbFJldmVhbCBsaWJyYXJ5XHJcbmRlY2xhcmUgdmFyIFNjcm9sbFJldmVhbDtcclxuXHJcbiQod2luZG93KS5sb2FkKCgpID0+IHtcclxuICAgIC8vc2V0IGEgZGVmYXVsdCB0aW1vdXQgZm9yIHRoZSBsb2FkZXIgYW5pbWF0aW9uXHJcbiAgICAvL3NvIHBlb3BsZSBjYW4gc2VlIGl0XHJcbiAgICBzZXRUaW1lb3V0KCgpID0+IHtcclxuICAgICAgICAvL2hpZGUgdGhlIGxvYWRlclxyXG4gICAgICAgICQoXCIuc2UtcHJlLWNvblwiKS5oaWRlKCk7XHJcbiAgICAgICAgLy9jYWxsIHBhZ2UgYW5pbWF0aW9uXHJcbiAgICAgICAgYW5pbWF0ZUhlYWRlcigpO1xyXG4gICAgICAgIGFuaW1hdGVTZWN0aW9ucygpO1xyXG4gICAgfSwgNTYwKTtcclxuXHJcbn0pO1xyXG5cclxuLy9mdW5jdGlvbiB0byBhbmltYXRlIHRoZSBoZWFkZXIgYnV0dG9uc1xyXG5mdW5jdGlvbiBhbmltYXRlSGVhZGVyKCk6IHZvaWQge1xyXG4gICAgdmFyIGRlbGF5ID0gMTAwO1xyXG4gICAgJCgnLm5hdi1pdGVtJykuZWFjaChmdW5jdGlvbiAoaW5kZXgsIGl0ZW0pIHtcclxuICAgICAgICBhbmltYXRlTmF2QnV0dG9uKCcjJyArIGl0ZW0uaWQsIGRlbGF5KTtcclxuICAgICAgICBkZWxheSArPSAxNTA7XHJcbiAgICB9KTtcclxufVxyXG4vL2Z1bmN0aW9uIHRvIGFuaW1hdGUgb25lIHBhcnRpY3VsYXIgYnV0dG9uIGJ5IGl0cyBJZCBuYW1lXHJcbi8vdXNpbmcgVmVsb2NpdHkgbGlicmFyeVxyXG5mdW5jdGlvbiBhbmltYXRlTmF2QnV0dG9uKGl0ZW1OYW1lLCBkZWxheSA9IDApOiB2b2lkIHtcclxuICAgICQoaXRlbU5hbWUpLnZlbG9jaXR5KCd0cmFuc2l0aW9uLmZsaXBYSW4nLCB7XHJcbiAgICAgICAgZGVsYXk6IGRlbGF5LFxyXG4gICAgICAgIG9wYWNpdHk6IDEsXHJcbiAgICAgICAgZHVyYXRpb246IDEwMDBcclxuICAgIH0pO1xyXG59XHJcblxyXG4vL3RoaXMgd2lsbCBhbmltYXRlIHNlY3Rpb25zIGluc2lkZSB0aGUgYm9keVxyXG4vL3VzaW5nIHNjcm9sUmV2ZWFsIGxpYnJhcnlcclxuZnVuY3Rpb24gYW5pbWF0ZVNlY3Rpb25zKCk6IHZvaWQge1xyXG4gICAgdmFyIGNvbmZpZyA9IHtcclxuICAgICAgICBkdXJhdGlvbjogMzAwLFxyXG4gICAgICAgIGRlbGF5OiA2MDAsXHJcbiAgICAgICAgZGlzdGFuY2U6ICcyMDBweCcsXHJcbiAgICAgICAgb3JpZ2luOiAncmlnaHQnLFxyXG4gICAgICAgIGVhc2luZzogJ2N1YmljLWJlemllcigxLCAxLCAxLCAxKSdcclxuXHJcbiAgICB9O1xyXG5cclxuICAgIGNvbnN0IHNyID0gKHdpbmRvdyBhcyBhbnkpLnNyID0gU2Nyb2xsUmV2ZWFsKCk7XHJcbiAgICAkKCcuYW5pbWF0ZWQnKS5lYWNoKChpbmRleCwgaXRlbSkgPT4ge1xyXG4gICAgICAgIHNyLnJldmVhbChpdGVtLCBjb25maWcpO1xyXG4gICAgfSk7XHJcbn0iXX0=
