let isOpenedChatData = true;
let isOpenedChatHistorySearch = false;

const chatDataElement = document.getElementById("id_chat_data");
const chatHistorySearchElement = document.getElementById(
  "id_chat_history_search"
);

document.getElementById("id_btn_chat_data").addEventListener("click", () => {
  if (isOpenedChatData) {
    chatDataElement.classList.add("d-none");
  } else {
    chatDataElement.classList.remove("d-none");
  }
  isOpenedChatData = !isOpenedChatData;
});

document
  .getElementById("id_btn_chat_history_search")
  .addEventListener("click", () => {
    if (isOpenedChatHistorySearch) {
      chatHistorySearchElement.classList.add("d-none");
    } else {
      chatHistorySearchElement.classList.remove("d-none");
    }
    isOpenedChatHistorySearch = !isOpenedChatHistorySearch;
  });

[].slice
  .call(document.getElementsByClassName("btn btn-float"))
  .forEach((element) => {
    const li = element.parentElement.parentElement;

    element.addEventListener("click", () => {
      if (li.classList.contains("active")) {
        return;
      }
      li.classList.add("active");
    });

    element.addEventListener("focusout", () => {
      li.classList.remove("active");
    });
  });

const peopleListItems = [].slice.call(
  document.getElementsByClassName("people-list-item")
);

peopleListItems.forEach((element) => {
  element.addEventListener("click", () => {
    element.classList.add("active");
    peopleListItems.forEach((otherElement) => {
      if (otherElement === element) {
        return;
      }
      if (otherElement.classList.contains("active")) {
        otherElement.classList.remove("active");
        return;
      }
    });
  });
});
