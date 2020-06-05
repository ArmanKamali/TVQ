"""
TODO: Add doc string.
"""

import os
import numpy as np


CLUSTERED_FILENAME_POSFIX = "_clustered"
CLUSTER_NAME_COLUMN_LABEL = "cluster_label"


class Base(object):
    """
    Base class containing common functionality to be used
    by the derived types. 
    """

    def get_repo_name(filename):
        """
        Extracts repository name from the given filename.

        :type  filename:    string
        :param filename:    The filename from which the repository 
                            name should be extracted.

        :rtype:     string
        :return:    Repository name.
        """
        filename = os.path.basename(filename)
        return (os.path.splitext(filename)[0]).replace(CLUSTERED_FILENAME_POSFIX, "")


    def get_input_files(input_path):
        """

        """
        files = []
        for root, dirpath, filenames in os.walk(input_path):
            for filename in filenames:
                if os.path.splitext(filename)[1] == ".csv" and \
                   not os.path.splitext(filename)[0].endswith(CLUSTERED_FILENAME_POSFIX):
                    files.append(os.path.join(root, filename))
        return files

    def get_clustered_files(input_path):
        """
        TODO: should return files whose filename ends with CLUSTERED_FILENAME_POSFIX
        """
        pass

    def get_citations_headers(publications):
        """
        Extracts the headers of columns containing citations of publications 
        from the given data frame.

        This method assumes the consecutive columns with numerical headers
        (starting from the first numerical header to the next non-numerical header)
        contain the citation count of publications. The negative and positive
        numerical headers are assumed to be containing citations belong to 
        before and after the tool was added to the repository, respectively.

        :type   publications:   pandas.core.frame.DataFrame
        :param  publications:   The dataframe from which to extract citations count.

        :returns:
            - list<string> pre:     The headers of columns containing citation counts 
                                    before the tool was added to the repository.
            - list<string> post:    The headers of columns containing citation counts 
                                    after the tool was added to the repository.
        """
        headers = publications.columns.values.tolist()
        pre = []
        post = []
        s = False
        for header in headers:
            try:
                v = float(header)
            except ValueError:
                if s: break
                else: continue

            s = True
            if v < 0:
                pre.append(header)
            else:
                post.append(header)

        return pre, post

    def get_vectors(publications, citations_per_year=False):
        """

        :type   publications:   pandas.core.frame.DataFrame
        :param  publications:   The dataframe from which to extract citations vectors.

        :returns:
        """
        pre_headers, post_headers = Base.get_citations_headers(publications)

        # A list of two-dimensional lists, first dimension is pre counts
        # and second dimension contains post citation counts.
        citations = []

        sums = []

        deltas = []

        # Lists contain citation counts before (pre) and after (post)
        # a tool was added to the repository.
        avg_pre = []
        avg_pst = []

        pre_citations = []
        post_citations = []
        for index, row in publications.iterrows():
            pre_vals = row.get(pre_headers).values.tolist()
            post_vals = row.get(post_headers).values.tolist()

            pre_citations.append(pre_vals)
            post_citations.append(post_vals)

            citations.append(pre_vals + post_vals)
            sums.append(np.sum(pre_vals + post_vals))
            avg_pre.append(np.average(pre_vals))
            avg_pst.append(np.average(post_vals))

            if citations_per_year:
                deltas.append(abs(np.average(post_vals) - np.average(pre_vals)))
            else:
                deltas.append(abs(np.max(post_vals) - np.max(pre_vals)))

        return citations, pre_citations, post_citations, sums, avg_pre, avg_pst, deltas