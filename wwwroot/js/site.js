// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var popoverTriggerList = [].slice.call(
  document.querySelectorAll('[data-bs-toggle="popover"]')
);
var popoverList = popoverTriggerList.map(function (popoverTriggerEl) {
  const popoverId = popoverTriggerEl.attributes["data-content-id"];
  if (popoverId) {
    const contentEl = $(`#${popoverId.value}`).html();
    return new bootstrap.Popover(popoverTriggerEl, {
      content: contentEl,
      html: true,
    });
  } else {
    //do something else cause data-content-id isn't there.
  }
});
