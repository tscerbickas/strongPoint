import { v4 as uuidv4 } from "uuid";

const getUserUniqueIdentifier = () => {
  const key = "uniqueIndentifier";

  var uniqueIndentifier = localStorage.getItem(key);
  if (uniqueIndentifier) {
    return uniqueIndentifier;
  }

  var uid = uuidv4();
  localStorage.setItem(key, uid);
  return uid;
};

export default getUserUniqueIdentifier;
