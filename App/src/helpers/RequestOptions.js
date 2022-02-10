import getUserUniqueIdentifier from "./UserUniqueIndentifier";

const getRequestOptions = (httpMethod, bodyObj) => {
  const requestOptions = {
    method: httpMethod,
    headers: new Headers({
      "Content-Type": "application/json",
      UniqueIdentifier: getUserUniqueIdentifier(),
    }),
  };

  if (httpMethod !== "GET") {
    requestOptions.body = bodyObj ? JSON.stringify(bodyObj) : "";
  }

  return requestOptions;
};

export default getRequestOptions;
