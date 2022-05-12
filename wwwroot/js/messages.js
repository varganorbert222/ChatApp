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
